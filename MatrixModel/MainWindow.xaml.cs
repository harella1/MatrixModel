using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace MatrixModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> FunctionalException;
        MatrixModelStructs matrixModelStructs;
        List<string> StructorList;
        List<Functional> FunctionalList;
        private string FileName;
        private string Path;
        public MainWindow()
        {
            matrixModelStructs = new MatrixModelStructs ();
            FunctionalException = new List<string>();
            FunctionalException.AddRange(new string[] { "GetHashCode", "ToString", "GetType", "Equals" });
            StructorList = new List<string>();
            FunctionalList = new List<Functional>();
            InitializeComponent();
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            btnLoad.IsEnabled = false;
            btnRun.IsEnabled = false;
            Assembly assembly = Assembly.LoadFile(Path);
            Debug.Write("FileLoaded");
            matrixModelStructs.Name = assembly.FullName;
            matrixModelStructs.StructorsList = new List<Structor>();
            Type[] TypesArray = assembly.GetTypes();
            foreach (Type type in TypesArray)
            {
                if (type.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase)
                    || type.Namespace == null
                    || type.Namespace.Contains("Annotations"))
                    continue;

                matrixModelStructs.StructorsList.Add(ReflectionHelper.LoadTypeObject(type));
               
            }
            foreach (Structor structs in matrixModelStructs.StructorsList)
            {
                foreach(Functional func in structs.FunctionalsList)
                {
                    if (!FunctionalList.Exists(x => x.Name == func.Name && x.ReturnType == func.ReturnType))
                        FunctionalList.Add(func);
                }
            }

//            CreateConceptExplorerFile(matrixModelStructs);
            CreateCSVFile(matrixModelStructs);
            btnLoad.IsEnabled = true;
         

           
        }

        private void CreateCSVFile(MatrixModelStructs matrixModelStructs)
        {
            try
            {
                List<FunctionalMatrix> functionalList;
                List<StructsMatrix> stractorList;
                CreateMatrixLists(matrixModelStructs, out functionalList, out stractorList);

                // Prepare the values
                var csv = new StringBuilder();
                stractorList.Select(s => csv.Append(s.Name + ","));

                var allLines = (from functional in functionalList
                                select new object[]
                                {
                    functional.Name,
                    functional.Identifier
                                });

                // Build the file content
                allLines.Select(line => csv.AppendLine(string.Join(",", line)+","));
 
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "csv (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, csv.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void CreateConceptExplorerFile(MatrixModelStructs matrixModelStructs)
        {
            try
            {
                List<FunctionalMatrix> functionalList;
                List<StructsMatrix> stractorList;
                CreateMatrixLists(matrixModelStructs, out functionalList, out stractorList);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new ASCIIEncoding();
                XElement root = new XElement("ConceptualSystem",
                    new XElement("Version", new XAttribute("MajorNumber", "1"), new XAttribute("MinorNumber", "0")),
                        new XElement("Contexts",
                            new XElement("Context", new XAttribute("Identifier", "0"), new XAttribute("Type", "Binary"),
                             new XElement("Attributes",
                                 from item in functionalList
                                 select new XElement("Attribute", new XAttribute("Identifier", item.Identifier),
                                     new XElement("Name", item.Name)
                                     )),
                                     new XElement("Objects",
                                         from item in stractorList
                                         select new XElement("Object",
                                                  new XElement("Name", item.Name),
                                                      new XElement("Intent",
                                                          from subItem in item.AttributeList
                                                          select new XElement("HasAttribute", new XAttribute("AttributeIdentifier", subItem.Identifier))))))));


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Cex (*.cex)|*.cex";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string save = saveFileDialog.FileName;
                    using (var writer = new XmlTextWriter(save, new UTF8Encoding(false)))
                    {
                        root.Save(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static void CreateMatrixLists(MatrixModelStructs matrixModelStructs, out List<FunctionalMatrix> functionalList, out List<StructsMatrix> stractorList)
        {
            functionalList = new List<FunctionalMatrix>();
            stractorList = new List<StructsMatrix>();
            int identifier = 0;
            foreach (Structor structor in matrixModelStructs.StructorsList)
            {
                foreach (Functional functionalItem in structor.FunctionalsList)
                {
                    FunctionalMatrix newFunctional = new FunctionalMatrix();
                    if (!functionalList.Exists(x => x.Name == functionalItem.Name))
                    {
                        newFunctional.Name = functionalItem.Name;
                        newFunctional.Identifier = identifier;
                        functionalList.Add(newFunctional);
                        identifier++;
                    }
                    else
                    {
                        newFunctional = functionalList.FirstOrDefault(x => x.Name == functionalItem.Name);
                    }
                    if (!stractorList.Exists(s => s.Name == structor.Name))
                    {
                        StructsMatrix newItem = new StructsMatrix();
                        newItem.Name = structor.Name;
                        newItem.AttributeList = new List<Attribute>();
                        newItem.AttributeList.Add(new Attribute() { Identifier = newFunctional.Identifier });
                        stractorList.Add(newItem);
                    }
                    else
                    {
                        StructsMatrix stractorItem = stractorList.FirstOrDefault(s => s.Name == structor.Name);
                        stractorItem.AttributeList.Add(new Attribute() { Identifier = newFunctional.Identifier });
                    }

                }
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dll |*.dll|Exe |*.exe";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                Debug.WriteLine("File Selected");
                Path = openFileDialog.FileName;
                btnRun.IsEnabled = true;
            }
        }



      
       
    }
}

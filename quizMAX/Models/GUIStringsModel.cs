using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace quizMAX.Models
{
    public class GUIstringsModel
    {
        readonly List<GUIstring> _guiStringsList;

        private class GUIstring
        {
            public string Name { get; set; }
            public string Str { get; set; }
            public GUIstring(string name, string str)
            {
                this.Name = name;
                this.Str = str;
            }
        }
        public string GetGUIstr(string name)
        {
            return this._guiStringsList.Find(x => x.Name == name).Str;
        }
        public GUIstringsModel()
        {
            this._guiStringsList = new List<GUIstring>();

            XmlReader reader = XmlReader.Create(@"Strings.xml");

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "string"))
                {
                    if (reader.HasAttributes)
                        this._guiStringsList.Add(new GUIstring(reader.GetAttribute("name"), reader.GetAttribute("str")));
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace XSLTransformStudents
{
    public class XSLTransformStudents
    {
        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();

            xslt.Load("../../student.xslt");
            xslt.Transform("../../../../students.xml", "../../../../students.html");
        }
    }
}

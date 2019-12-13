
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSaveToFileSysWPFFW
{
    public class SaveToFileSysFW
    {


        public List<string> WriteOutAc4yObjectNameList()
        {
            StringToPascalCase stringToPascalCase = new StringToPascalCase();
            List<string> names = new List<string>();

            ListInstanceByNameResponse listInstanceByNameResponse =
                new Ac4yObjectObjectService(sqlConn).ListInstanceByName(
                    new ListInstanceByNameRequest() { TemplateName = TemplateName }
                );

            foreach (var element in listInstanceByNameResponse.Ac4yObjectList)
            {
                string xml = serialize(element, typeof(Ac4yObject));
                string templateSimpledId = stringToPascalCase.Convert(element.TemplatePublicHumanId).ToUpper();
                string name = element.SimpledHumanId + "@" + templateSimpledId + "@Ac4yObject";
                names.Add(name);

                writeOut(xml, name, outPath);
            }

            return names;
        }
    }
}

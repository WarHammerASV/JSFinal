using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace JScntrl
{
    public partial class Main : System.Web.UI.Page
    {
        static public bool serializeFlag = true;
        static public List<Parameter> outputList = new List<Parameter>();
        static public List<Parameter> parameterList = new List<Parameter>();


        protected void Page_Load(object sender, EventArgs e)
        {
                XMLSerializer ser = new XMLSerializer();
                parameterList = ser.DeserializeXml(@"W:/C#/JScntrl/JScntrl/Input.xml");
                foreach (var parameter in parameterList)
                {
                    AddUserParameter(parameter);
                }
            this.DataBind();
            Button save = new Button();
            save.Text = "Сохранить";
            save.ID = "saveButton";
            save.Click += SaveClick;
            form1.Controls.Add(save);
        }


        private void AddUserParameter(Parameter parameter)
        {
            var parameterControl = (CommonParameterControl)LoadControl("UserControl.ascx");
            parameterControl.InitializeFields(parameter.Id, parameter.Name, parameter.Description, parameter.Type, parameter.Value);
            form1.Controls.Add(parameterControl);
        }


        private void SaveClick(object sender, EventArgs e)
        {
            serializeFlag = true;

                XmlSerializer serializer = new XmlSerializer(typeof(List<Parameter>), new XmlRootAttribute("Parameters"));

                Parameter par1 = new Parameter();
                Parameter par2 = new Parameter();
                Parameter par3 = new Parameter();
                Parameter par4 = new Parameter();
                Parameter par5 = new Parameter();
                Parameter par6 = new Parameter();
                Parameter par7 = new Parameter();
                Parameter par8 = new Parameter();


                using (FileStream fs = new FileStream(@"W:/C#/JScntrl/JScntrl/Output.xml", FileMode.OpenOrCreate))
                {
                   
                par1.Id = "BillingCode";
                par1.Name = "Billing Code";
                par1.Description = "This is blah-blah-blah";
                par1.Value = Request.Form["ctl04$ctl04"];
                par1.Type = "System.String";
                outputList.Add(par1);
                par2.Id = "BillingCode";
                par2.Name = "Billing Code";
                par2.Description = "This is blah-blah-blah";
                par2.Value = Request.Form["ctl05$ctl04"];
                par2.Type = "System.String";
                outputList.Add(par2);
                par3.Id = "BillingCode";
                par3.Name = "Billing Code";
                par3.Description = "This is blah-blah-blah";
                par3.Value = Request.Form["ctl06$ctl04"];
                par3.Type = "System.String";
                outputList.Add(par3);
                par4.Id = "AbandonmentRate";
                par4.Name = " Nuisance call abandonment rate";
                par4.Description = "This is blah-blah-blah";
                par4.Value = Request.Form["ctl07$ctl04"];
                    if (int.Parse(par4.Value) > 255 || int.Parse(par4.Value) < -255)
                    {
                        Response.Write("Значение должно быть от -255 до 255");
                        serializeFlag = false;
                    }
                par4.Type = "System.Int32";
                outputList.Add(par4);
                par5.Id = "AbandonmentRate";
                par5.Name = " Nuisance call abandonment rate";
                par5.Description = "This is blah-blah-blah";
                par5.Value = Request.Form["ctl08$ctl04"];
                    if (int.Parse(par5.Value) > 255 || int.Parse(par5.Value) < -255)
                    {
                        Response.Write("Значение должно быть от -255 до 255");
                        serializeFlag = false;
                    }
                    par5.Type = "System.Int32";
                outputList.Add(par5);
                par6.Id = "AbandonmentRate";
                par6.Name = " Nuisance call abandonment rate";
                par6.Description = "This is blah-blah-blah";
                par6.Value = Request.Form["ctl09$ctl04"];
                    if (int.Parse(par6.Value) > 255 || int.Parse(par6.Value) < -255)
                    {
                        Response.Write("Значение должно быть от -255 до 255");
                        serializeFlag = false;
                    }
                    par6.Type = "System.Int32";
                outputList.Add(par6);
                    par7.Id = "AbandonmentRate";
                    par7.Name = " Nuisance call abandonment rate";
                    par7.Description = "This is blah-blah-blah";
                    par7.Value = Request.Form["ctl10$ctl04"];
                    if (par7.Value == "on")
                        par7.Value = "True";
                    else
                        par7.Value = "False";
                    par7.Type = "System.Boolean";
                    outputList.Add(par7);
                    par8.Id = "AbandonmentRate";
                    par8.Name = " Nuisance call abandonment rate";
                    par8.Description = "This is blah-blah-blah";
                    par8.Value = Request.Form["ctl11$ctl04"];
                    if (par8.Value == "on")
                        par8.Value = "True";
                    else
                        par8.Value = "False";
                    par8.Type = "System.Boolean";
                    outputList.Add(par8);

                    if (serializeFlag)
                    {
                        serializer.Serialize(fs, outputList);
                    }
                }      
        }


    }
}
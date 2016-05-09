using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JScntrl
{
    public partial class CommonParameterControl : System.Web.DynamicData.FieldTemplateUserControl
    {
        static int count = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InitializeFields(string id, string name, string description, string type, string value)
        {
            Id.Text = id;
            Name.Text = name;
            Description.Text = description;
            parType.Text = type;
            if (type == "System.Boolean")
            {
                var boolBox = new CheckBox();
                typeValue.Controls.Add(boolBox);
                boolBox.Checked = Convert.ToBoolean(value);
                boolBox.AutoPostBack = true;
                if (value == "True")
                    count++;
                boolBox.CheckedChanged += UpdateCheckBoxBox;
            }
            else
               if (type == "System.String")
            {
                var textBox = new TextBox();

                typeValue.Controls.Add(textBox);
                textBox.Text = value;
                textBox.Attributes["maxLength"] = "10";
            }
            else
                   if (type == "System.Int32")
            {
                var textBox = new TextBox();
                typeValue.Controls.Add(textBox);
                textBox.Text = value;
                textBox.Attributes["onKeyUp"] = "javascript:IntegerValidation(this);";
                textBox.Attributes["maxValue"] = "255";
                textBox.Attributes["minValue"] = "-255";
            }
        }

        protected void UpdateCheckBoxBox(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                var field = (CheckBox)sender;
                if (field.Checked)
                    count++;
                if (field.Checked == false)
                {
                    count--;
                }
                if (count == 0)
                {
                    Response.Write("Нужно поставить галку");
                }            
            }
            else
            {
                throw new NotImplementedException();
            }
            count--;
        }
    
    }
}
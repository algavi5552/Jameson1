using System;
using System.IO;
using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Text;
using System.Windows;
//using System.Globalization;
//using Newtonsoft.Json.Converters;

namespace Jameson
{
    public partial class MainWindow : Window
    {
        RootObject kappa;
        int ObjNumber = 1;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Load(object sender, RoutedEventArgs e)
        {
            ObjNumber = Convert.ToInt32(strObjNumber.Text) - 1;//переменная для номера экземпляра класса, отображаемого на экране, начинается с 1

            //читаем данные из input-десериализация
            //читаем JSON из файла и десериализируем полученную из него строку
            string jsonSerial = File.ReadAllText(@"input2.json");
            kappa = JsonConvert.DeserializeObject<RootObject>(jsonSerial);

            //отправляем данные в output-сериализация
            //сериализируем JSON в строку,затем пишем эту строку в файл
            string path = @"output.json";
            string createText = JsonConvert.SerializeObject(kappa.D.items[ObjNumber]);
            File.WriteAllText(path, createText);


            //блок вывода информации на экран
            strName.Text = kappa.D.items[ObjNumber].name;
            strAddress.Text = kappa.D.items[ObjNumber].address;
            strType.Text = Convert.ToString(kappa.D.items[ObjNumber].type);
            strFlors.Text = Convert.ToString(kappa.D.items[ObjNumber].flors);
            strLogin.Text = kappa.D.items[ObjNumber].login;
            strGroup.Text = Convert.ToString(kappa.D.items[ObjNumber].group);
            strPhones.Text = string.Empty;
            if (kappa.D.items[ObjNumber].phones != null)
                for (int k = 0; k < kappa.D.items[ObjNumber].phones.Count; k++)
                {
                      var x = kappa.D.items[ObjNumber].phones[k];
                    var type = x.GetType();
            strPhones.Text += Convert.ToString(kappa.D.items[ObjNumber].phones[k]);//выводим лист обьектов на экран
        }

    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //добавляем кнопку 'Сохранить'


        kappa.D.items[ObjNumber].name = strName.Text;
        kappa.D.items[ObjNumber].address = strAddress.Text;
        kappa.D.items[ObjNumber].type = Convert.ToInt32(strType.Text);
        kappa.D.items[ObjNumber].flors = Convert.ToInt32(strFlors.Text);
        kappa.D.items[ObjNumber].login = strLogin.Text;
        kappa.D.items[ObjNumber].group = Convert.ToInt32(strGroup.Text);
        //     kappa.D.items[ObjNumber].phones = (strPhones.Text); //а как конвертировать стринг в обджект?



        File.WriteAllText(@"output.json", JsonConvert.SerializeObject(kappa));
    }

}
       
   

}
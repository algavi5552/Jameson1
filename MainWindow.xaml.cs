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
        int quantity = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Load(object sender, RoutedEventArgs e)
        {
            ObjNumber = Convert.ToInt32(strObjNumber.Text);//переменная для номера экземпляра класса, отображаемого на экране, начинается с 1

            //читаем данные из input-десериализация
            //читаем JSON из файла и десериализируем полученную из него строку
            string jsonSerial = File.ReadAllText(@"input2.json");
            kappa = JsonConvert.DeserializeObject<RootObject>(jsonSerial);

            //отправляем данные в output-сериализация
            //сериализируем JSON в строку,затем пишем эту строку в файл
            string path = @"output.json";
            string createText = JsonConvert.SerializeObject(kappa.D.items[ObjNumber]);
            File.WriteAllText(path, createText);

            int quantity = kappa.D.items.Count;// ввели переменную для количества существующих итемов\экземпляров класса

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
                    //  var x = kappa.D.items[ObjNumber].phones[k];
                    //var type = x.GetType();
            strPhones.Text += Convert.ToString(kappa.D.items[ObjNumber].phones[k]);//выводим лист обьектов на экран
        }

    }
        private void Button_Dec(object sender, RoutedEventArgs e)//кнопка меняет номер читаемого элемента -1
        {
            strObjNumber.Text = Convert.ToString(ObjNumber--);

        }
        private void Button_Inc(object sender, RoutedEventArgs e)//кнопка меняет номер читаемого элемента +1
        {
            strObjNumber.Text = Convert.ToString(ObjNumber++);
        }
        
            //Delete and Add есть сомнения в работе методов

        private void Button_Delete(object sender, RoutedEventArgs e)//кнопка удаляет текущий экземпляр класса
        {
            
            kappa.D.items.RemoveAt(ObjNumber); //удаление экземпляра чет не работает remove and dispose both

            File.WriteAllText(@"output.json", JsonConvert.SerializeObject(kappa));
        }
        private void Button_Add(object sender, RoutedEventArgs e)//кнопка добавляет новый экземпляр класса
        {
            //надо добавить новый экземпляр класса?а если более 1?
            quantity++;
            var newItem = new Item();

            newItem.name = strName.Text;
            newItem.address = strAddress.Text;
            newItem.type = Convert.ToInt32(strType.Text);
            newItem.flors = Convert.ToInt32(strFlors.Text);
            newItem.login = strLogin.Text;
            newItem.group = Convert.ToInt32(strGroup.Text);

            kappa.D.items.Add(newItem);

            //kappa.D.items[quantity].name = strName.Text;
            //kappa.D.items[quantity].address = strAddress.Text;
            //kappa.D.items[quantity].type = Convert.ToInt32(strType.Text);
            //kappa.D.items[quantity].flors = Convert.ToInt32(strFlors.Text);
            //kappa.D.items[quantity].login = strLogin.Text;
            //kappa.D.items[quantity].group = Convert.ToInt32(strGroup.Text);
            //kappa.D.items[ObjNumber].phones = (strPhones.Text); //а как конвертировать стринг в обджект?

            File.WriteAllText(@"output.json", JsonConvert.SerializeObject(kappa));
        }


             //Delete and Add есть сомнения в работе методов



        private void Button_Click(object sender, RoutedEventArgs e)//добавляем кнопку 'Сохранить'
        {
        
        kappa.D.items[ObjNumber].name = strName.Text;
        kappa.D.items[ObjNumber].address = strAddress.Text;
        kappa.D.items[ObjNumber].type = Convert.ToInt32(strType.Text);
        kappa.D.items[ObjNumber].flors = Convert.ToInt32(strFlors.Text);
        kappa.D.items[ObjNumber].login = strLogin.Text;
        kappa.D.items[ObjNumber].group = Convert.ToInt32(strGroup.Text);
        //kappa.D.items[ObjNumber].phones = (strPhones.Text); //а как конвертировать стринг в обджект?

        File.WriteAllText(@"output.json", JsonConvert.SerializeObject(kappa));
    }

}
       
   

}
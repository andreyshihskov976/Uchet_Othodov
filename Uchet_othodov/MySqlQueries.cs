using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uchet_othodov
{
    public class MySqlQueries
    {
        //Запросы Select

        public string Select_Otdely = $@"SELECT ID_Otdela AS 'ID Отдела', Name AS 'Наименование отдела' FROM otdely;";

        public string Select_Otdely_ComboBox = $@"SELECT Name AS 'Наименование отдела' FROM otdely;";

        public string Select_ID_Otdela = $@"SELECT ID_Otdela FROM otdely WHERE Name = @Value1";

        public string Select_Organizacii = $@"SELECT ID_Organizacii AS 'ID Организации', Name AS 'Наименование организации' FROM organizacii;";

        public string Select_Organizacii_ComboBox = $@"SELECT Name AS 'Наименование организации' FROM organizacii;";

        public string Select_ID_Organizacii = $@"SELECT ID_Organizacii FROM organizacii WHERE Name = @Value1";

        public string Select_Othody = "SELECT ID_Othoda AS 'ID Отхода', Name AS 'Наименование отхода', Class_othoda AS 'Класс отхода', Ed_Izm AS 'Единицы измерения' FROM othody;";

        public string Select_Othody_ComboBox = $@"SELECT Name AS 'Наименование отхода' FROM othody";

        public string Select_ID_Othoda = $@"SELECT ID_Othoda FROM othody WHERE Name = @Value1";

        public string Select_Sotrudniki = $@"SELECT ID_Sotrudnika AS 'ID Сотрудника', CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS 'ФИО Сотрудника', 
otdely.Name AS 'Наименование отдела', Telephone AS 'Номер телефона' 
FROM sotrudniki INNER JOIN otdely ON sotrudniki.ID_Otdela = otdely.ID_Otdela;";

        public string Select_Pribytiya = $@"SELECT ID_Pribytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_pribytiya AS 'Дата прибытия', Kolichestvo AS 'Количество'
FROM pribytiya INNER JOIN kartochka ON pribytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela;";

        public string Select_Ubytiya = $@"SELECT ID_Ubytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_ubytiya AS 'Дата убытия', Kolichestvo AS 'Количество', organizacii.Name AS 'Получила организация'
FROM ubytiya INNER JOIN kartochka ON ubytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN organizacii ON ubytiya.ID_Organizacii = organizacii.ID_Organizacii;";

        public string Select_Kartochka = $@"SELECT ID_Kartochki AS 'ID Карточки', otdely.Name AS 'Наименование отдела', othody.Name AS 'Наименование отхода',
Date_Nachala_Sbora AS 'Дата начала сбора',Date_Okonchaniya_Sbora AS 'Дата окончания сбора',
Planiruemoe_Kolichestvo AS 'Планируемое количество'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda;";

        public string Select_Kartocka_ComboBox = $@"SELECT CONCAT(ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda;";

        public string Select_ID_Kartochki = $@"SELECT ID_Kartochki 
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
WHERE CONCAT(ID_Kartochki,' (', otdely.Name,')') = @Value1";

        //Запросы Select



        //Запросы Insert

        public string Insert_Otdely = $@"INSERT INTO otdely (Name) VALUES (@Value1);";

        public string Insert_Organizacii = $@"INSERT INTO organizacii (Name) VALUES (@Value1);";

        public string Insert_Othody = $@"INSERT INTO othody (Name, Class_othoda, Ed_Izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Sotrudniki = $@"INSERT INTO sotrudniki (Familiya, Imya, Otchestvo, ID_Otdela, Telephone) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Pribytiya = $@"";

        public string Insert_Ubytiya = $@"";

        public string Insert_Kartochka = $@"";

        //Запросы Insert



        //Запросы Update

        public string Update_Otdely = $@"UPDATE otdely SET Name = @Value1 WHERE ID_Otdela = @ID;";

        public string Update_Organizacii = $@"UPDATE organizacii SET Name = @Value1 WHERE ID_Organizacii = @ID;";

        public string Update_Othody = $@"UPDATE othody SET Name = @Value1, Class_othoda = @Value2, Ed_Izm = @Value3 WHERE ID_Othoda = @ID;";

        public string Update_Sotrudniki = $@"UPDATE sotrudniki SET Familiya = @Value1, Imya = @Value2, Otchestvo = @Value3, ID_Otdela = @Value4, Telephone = @Value5 WHERE  ID_Sotrudnika = @ID;";

        public string Update_Pribytiya = $@"";

        public string Update_Ubytiya = $@"";

        public string Update_Kartochka = $@"";

        //Запросы Update



        //Запросы Delete

        public string Delete_Otdely = $@"DELETE FROM otdely WHERE ID_Otdela = @ID";

        public string Delete_Organizacii = $@"DELETE FROM organizacii WHERE ID_Organizacii = @ID";

        public string Delete_Othody = $@"DELETE FROM othody WHERE ID_Othoda = @ID";

        public string Delete_Sotrudniki = $@"DELETE FROM sotrudniki WHERE ID_Sotrudnika = @ID";

        public string Delete_Pribytiya = $@"DELETE FROM pribytiya WHERE ID_Pribytiya = @ID";

        public string Delete_Ubytiya = $@"DELETE FROM ubytiya WHERE ID_Ubatiya = @ID";

        public string Delete_Kartocka = $@"DELETE FROM kartochka WHERE ID_Kartochki = @ID";

        //Запросы Delete
    }
}

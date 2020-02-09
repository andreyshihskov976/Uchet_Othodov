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

        public string Select_Otdely_ComboBox_by_ID = $@"SELECT Name AS 'Наименование отдела' FROM otdely WHERE ID_Otdela = @ID;";

        public string Select_ID_Otdela = $@"SELECT ID_Otdela FROM otdely WHERE Name = @Value1";

        public string Select_Organizacii = $@"SELECT ID_Organizacii AS 'ID Организации', Name AS 'Наименование организации' FROM organizacii;";

        public string Select_Organizacii_ComboBox = $@"SELECT Name AS 'Наименование организации' FROM organizacii;";

        public string Select_ID_Organizacii = $@"SELECT ID_Organizacii FROM organizacii WHERE Name = @Value1";

        public string Select_Othody = "SELECT ID_Othoda AS 'ID Отхода', Name AS 'Наименование отхода', Class_othoda AS 'Класс отхода', Ed_Izm AS 'Единицы измерения' FROM othody;";

        public string Select_Othody_ComboBox = $@"SELECT Name AS 'Наименование отхода' FROM othody";

        public string Select_ID_Othoda = $@"SELECT ID_Othoda FROM othody WHERE Name = @Value1";

        public string Select_Sotrudniki = $@"SELECT ID_Sotrudnika AS 'ID Сотрудника', CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS 'ФИО Сотрудника', 
otdely.Name AS 'Наименование отдела', Telephone AS 'Номер телефона' 
FROM sotrudniki LEFT JOIN otdely ON sotrudniki.ID_Otdela = otdely.ID_Otdela;";

        public string Select_Sotrudniki_Otdela = $@"SELECT ID_Sotrudnika AS 'ID Сотрудника', CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS 'ФИО Сотрудника', 
otdely.Name AS 'Наименование отдела', Telephone AS 'Номер телефона' 
FROM sotrudniki LEFT JOIN otdely ON sotrudniki.ID_Otdela = otdely.ID_Otdela
WHERE otdely.ID_Otdela = @ID;";

        public string Select_Pribytiya = $@"SELECT ID_Pribytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_pribytiya AS 'Дата прибытия', Kolichestvo AS 'Количество'
FROM pribytiya INNER JOIN kartochka ON pribytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela;";

        public string Select_Pribytiya_Kartochki = $@"SELECT ID_Pribytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_pribytiya AS 'Дата прибытия', Kolichestvo AS 'Количество'
FROM pribytiya INNER JOIN kartochka ON pribytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
WHERE kartochka.ID_kartochki = @ID";

        public string Select_Sum_Pribytiya = $@"SELECT SUM(pribytiya.Kolichestvo) 
FROM pribytiya INNER JOIN kartochka ON pribytiya.ID_Kartochki = kartochka.ID_Kartochki
WHERE pribytiya.ID_Kartochki = @ID;";

        public string Select_Ubytiya = $@"SELECT ID_Ubytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_ubytiya AS 'Дата выбытия', Kolichestvo AS 'Количество', organizacii.Name AS 'Получила организация'
FROM ubytiya INNER JOIN kartochka ON ubytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN organizacii ON ubytiya.ID_Organizacii = organizacii.ID_Organizacii;";

        public string Select_Ubytiya_Kartochki = $@"SELECT ID_Ubytiya AS 'ID Прибытия', CONCAT(kartochka.ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №', 
Date_ubytiya AS 'Дата выбытия', Kolichestvo AS 'Количество', organizacii.Name AS 'Получила организация'
FROM ubytiya INNER JOIN kartochka ON ubytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN organizacii ON ubytiya.ID_Organizacii = organizacii.ID_Organizacii
WHERE kartochka.ID_Kartochki = @ID;";

        public string Select_Kartochka = $@"SELECT ID_Kartochki AS 'ID Карточки', otdely.Name AS 'Наименование отдела', othody.Name AS 'Наименование отхода',
Date_Nachala_Sbora AS 'Дата начала сбора',Date_Okonchaniya_Sbora AS 'Дата окончания сбора',
Planiruemoe_Kolichestvo AS 'Планируемое количество'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda;";

        public string Select_Kartochka_Otdela = $@"SELECT ID_Kartochki AS 'ID Карточки', otdely.Name AS 'Наименование отдела', othody.Name AS 'Наименование отхода',
Date_Nachala_Sbora AS 'Дата начала сбора',Date_Okonchaniya_Sbora AS 'Дата окончания сбора',
Planiruemoe_Kolichestvo AS 'Планируемое количество'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda
WHERE otdely.ID_Otdela = @ID;";

        public string Select_Kartocka_ComboBox = $@"SELECT CONCAT(ID_Kartochki,' (', otdely.Name,')') AS 'Карточка, №'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda;";

        public string Select_ID_Kartochki = $@"SELECT ID_Kartochki 
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
WHERE CONCAT(ID_Kartochki,' (', otdely.Name,')') = @Value1";

        public string Select_Kartochka_Identify = $@"SELECT kartochka.Identify FROM kartochka WHERE kartochka.ID_Kartochki = @ID;";

        public string Select_Kartochka_Ostatok = $@"SELECT kartochka.Planiruemoe_Kolichestvo - (SELECT 
SUM(pribytiya.Kolichestvo) 
FROM pribytiya 
WHERE pribytiya.ID_Kartochki = @ID
GROUP BY pribytiya.ID_Kartochki)
FROM kartochka INNER JOIN pribytiya ON kartochka.ID_Kartochki = pribytiya.ID_Kartochki
WHERE kartochka.ID_Kartochki = @ID
GROUP BY kartochka.ID_Kartochki;";

        public string Select_Kartochka_Passport = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT(DATE_FORMAT(ubytiya.Date_ubytiya,'%d %M% %Y'), ';',othody.Name, ';', otdely.Name, ';', organizacii.Name)
FROM ubytiya INNER JOIN kartochka ON ubytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN organizacii ON ubytiya.ID_Organizacii = organizacii.ID_Organizacii
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda
WHERE ubytiya.ID_Kartochki = @ID;";

        public string Select_Avtorizacia = $@"SELECT EXISTS(SELECT dostup.ID_Sotrudnika, dostup.Parol 
FROM dostup INNER JOIN sotrudniki ON dostup.ID_Sotrudnika = sotrudniki.ID_Sotrudnika 
WHERE dostup.Parol = @Value2 
AND dostup.ID_Sotrudnika = (SELECT sotrudniki.ID_Sotrudnika FROM sotrudniki WHERE CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo) = @Value1));";

        public string Select_SignIn = $@"SELECT sotrudniki.ID_Otdela
FROM sotrudniki WHERE sotrudniki.ID_Sotrudnika = (
SELECT sotrudniki.ID_Sotrudnika 
FROM sotrudniki 
WHERE CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo) = @Value1);";

        public string Avtorizacia = $@"SELECT CASE(SELECT EXISTS(SELECT sotrudniki.ID_Sotrudnika, sotrudniki.ID_Otdela
 FROM sotrudniki WHERE sotrudniki.Familiya = @Value1))
WHEN 1
THEN(SELECT sotrudniki.ID_Otdela
FROM sotrudniki WHERE sotrudniki.Familiya = @Value1)
END";

        public string Last_Insert_ID = $@"SELECT LAST_INSERT_ID();";

        //Запросы Select



        //Запросы Insert

        public string Insert_Otdely = $@"INSERT INTO otdely (Name) VALUES (@Value1);";

        public string Insert_Organizacii = $@"INSERT INTO organizacii (Name) VALUES (@Value1);";

        public string Insert_Othody = $@"INSERT INTO othody (Name, Class_othoda, Ed_Izm) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Sotrudniki = $@"INSERT INTO sotrudniki (Familiya, Imya, Otchestvo, ID_Otdela, Telephone) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Pribytiya = $@"INSERT INTO pribytiya 
(ID_Kartochki, Date_pribytiya, Kolichestvo) VALUES (@ID, @Value1, @Value2);";

        public string Insert_Ubytiya = $@"INSERT INTO ubytiya 
(ID_Kartochki, Date_ubytiya, Kolichestvo, ID_Organizacii) VALUES (@ID, @Value1, @Value2, @Value3);
UPDATE kartochka 
SET Identify='1' WHERE ID_Kartochki = @ID;";

        public string Insert_Kartochka = $@"INSERT INTO kartochka
(`ID_Otdela`, `ID_Othoda`, `Date_Nachala_Sbora`, `Date_Okonchaniya_Sbora`, `Planiruemoe_Kolichestvo`, `Identify`) 
VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, b'0');";

        //Запросы Insert



        //Запросы Update

        public string Update_Otdely = $@"UPDATE otdely SET Name = @Value1 WHERE ID_Otdela = @ID;";

        public string Update_Organizacii = $@"UPDATE organizacii SET Name = @Value1 WHERE ID_Organizacii = @ID;";

        public string Update_Othody = $@"UPDATE othody SET Name = @Value1, Class_othoda = @Value2, Ed_Izm = @Value3 WHERE ID_Othoda = @ID;";

        public string Update_Sotrudniki = $@"UPDATE sotrudniki SET Familiya = @Value1, Imya = @Value2, Otchestvo = @Value3, ID_Otdela = @Value4, Telephone = @Value5 WHERE  ID_Sotrudnika = @ID;";

        public string Update_Pribytiya = $@"";

        public string Update_Ubytiya = $@"";

        public string Update_Kartochka = $@"UPDATE kartochka
SET ID_Otdela = @Value1, ID_Othoda = @Value2, Date_Nachala_Sbora = @Value3, Date_Okonchaniya_Sbora = @Value4, Planiruemoe_Kolichestvo = @Value5 
WHERE ID_Kartochki = @ID;";

        //Запросы Update



        //Запросы Delete

        public string Delete_Otdely = $@"DELETE FROM otdely WHERE ID_Otdela = @ID";

        public string Delete_Organizacii = $@"DELETE FROM organizacii WHERE ID_Organizacii = @ID";

        public string Delete_Othody = $@"DELETE FROM othody WHERE ID_Othoda = @ID";

        public string Delete_Sotrudniki = $@"DELETE FROM sotrudniki WHERE ID_Sotrudnika = @ID";

        public string Delete_Pribytiya = $@"DELETE FROM pribytiya WHERE ID_Pribytiya = @ID";

        public string Delete_Ubytiya = $@"DELETE FROM ubytiya WHERE ID_Ubytiya = @ID";

        public string Delete_Kartochka = $@"DELETE FROM kartochka WHERE ID_Kartochki = @ID";

        //Запросы Delete
    }
}

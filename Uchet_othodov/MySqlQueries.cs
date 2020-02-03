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

        public string Select_Organizacii = $@"SELECT ID_Organizacii AS 'ID Организации', Name AS 'Наименование организации' FROM organizacii;";

        public string Select_Othody = "SELECT ID_Othoda AS 'ID Отхода', Name AS 'Наименование отхода', Class_othoda AS 'Класс отхода', Ed_Izm AS 'Единицы измерения' FROM othody";

        public string Select_Sotrudniki = $@"SELECT ID_Sotrudnika AS 'ID Сотрудника', CONCAT(Familiya, ' ', Imya, ' ', Otchestvo) AS 'ФИО Сотрудника', 
otdely.Name AS 'Наименование отдела', Telephone AS 'Номер телефона' 
FROM sotrudniki INNER JOIN otdely ON sotrudniki.ID_Otdela = otdely.ID_Otdela;";

        public string Select_Pribytiya = $@"SELECT ID_Pribytiya AS 'ID Прибытия', kartochka.ID_Kartochki AS 'Записано на карточку №', 
Date_pribytiya AS 'Дата прибытия', Kolichestvo AS 'Количество'
FROM pribytiya INNER JOIN kartochka ON pribytiya.ID_Kartochki = kartochka.ID_Kartochki;";

        public string Select_Ubytiya = $@"SELECT ID_Ubytiya AS 'ID Прибытия', kartochka.ID_Kartochki AS 'Записано на карточку №', 
Date_ubytiya AS 'Дата убытия', Kolichestvo AS 'Количество', organizacii.Name AS 'Получила организация'
FROM ubytiya INNER JOIN kartochka ON ubytiya.ID_Kartochki = kartochka.ID_Kartochki
INNER JOIN organizacii ON ubytiya.ID_Organizacii = organizacii.ID_Organizacii;";

        public string Select_Kartochka = $@"SELECT ID_Kartochki AS 'ID Карточки', otdely.Name AS 'Наименование отдела', othody.Name AS 'Наименование отхода',
Date_Nachala_Sbora AS 'Дата начала сбора',Date_Okonchaniya_Sbora AS 'Дата окончания сбора',
Planiruemoe_Kolichestvo AS 'Планируемое количество'
FROM kartochka INNER JOIN otdely ON kartochka.ID_Otdela = otdely.ID_Otdela
INNER JOIN othody ON kartochka.ID_Othoda = othody.ID_Othoda;";

        //Запросы Select
    }
}

using System;

namespace Kurs_Project
{
    public class errors
    {
        public const string mistake1 = "Неправильно введено имя файла";
        public const string mistake2 = "Неправильно введены данные";
        public const string mistake3 = "Такой логин уже есть в справочнике";
        public const string mistake4 = "Такого логина нет в справочнике";
        public const string mistake5 = "Невозможно добавить запись, так как нет связанного логина в 1 справочнике";
        public const string mistake6 = "Такой записи нет в справочнике 2";
        public const string mistake7 = "Есть связанная запись во втором справочнике. Удалите сначала её, прежде, чем удалять из этого справочника";
        
        public const string mistake8 =
            "В файле существует запись, у которой нет связного логина в справочнике 1. Проверьте данные";
        public const string mistake9 = "Таких записей нет";
        public const string mistake10 = "Для начала сформируйте отчет, прежде чем выгружать его!";
        public const string mistake11 = "Такого файла нет или файл был пуст";
        public const string completeDelete = "Запись успешно удалена";
        public const string completeAdd = "Запись успешно сохранена";
        public const string completeLoad = "Загрузка выполнена";
        public const string completeSave = "Сохранение выполнено";
        
    }
}
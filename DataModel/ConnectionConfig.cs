using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataModel
{
    public class ConnectionConfig
    {
        public const string
        Sqlite = "Sqlite";

        /// <summary>
        /// Получение строки подключения к БД
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetConnectionStrings(string key)
        {
            // Получить поток ресурса по имени файла
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("ConnectionConfig.appsettings.json");

            var builder = new ConfigurationBuilder();

            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonStream(resourceStream!);
            // создаем конфигурацию
            var config = builder.Build();

            // получаем строку подключения
            var connectionString = config.GetConnectionString(key);

            return connectionString ?? throw new ArgumentException($"Такой строки подключения не существует: {key}", key);
        }

        /// <summary>
        /// Получение пути файла .exe для перехода к программным модулям
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        //public static string GetPath(string key)
        //{
        //    // Получить поток ресурса по имени файла
        //    var assembly = Assembly.GetExecutingAssembly();
        //    var resourceStream = assembly.GetManifestResourceStream("ConnectionConfig.appsettings.json");

        //    var builder = new ConfigurationBuilder();

        //    // получаем конфигурацию из файла appsettings.json
        //    builder.AddJsonStream(resourceStream!);
        //    // создаем конфигурацию
        //    var config = builder.Build();

        //    var section = config.GetSection("ModulePaths");
        //    var result = section.GetChildren()?.FirstOrDefault(c => c.Key == key)?.Value;
        //    // ?? throw new ArgumentException($"Такой путь не сохранён: {key}", key);
        //    if (!File.Exists(result)) throw new ArgumentException($"Такой путь не сохранён: {key}", key);
        //    return result;
        //}
    }
}

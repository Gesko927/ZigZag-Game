using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ZigZag.ConsoleUI
{
    class GameStatistic
    {
        #region Nested Classes

        [Serializable()]
        public class StatisticItemHolder
        {
            #region Properties

            public string Name { get; set; }
            public int Score { get; set; }

            #endregion

            #region Constructors

            public StatisticItemHolder()
            {
                Name = string.Empty;
                Score = 0;
            }

            public StatisticItemHolder(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }

            #endregion
        }

        #endregion

        #region Private Fields

        private readonly string _dirPath;
        private readonly string _filePath;
        private readonly BinaryFormatter _binaryFormatter;

        #endregion

        #region Properties
        [XmlAttribute]
        public List<StatisticItemHolder> Top { get; private set; }

        #endregion

        #region Constructors

        public GameStatistic()
        {
            _dirPath = Assembly.GetEntryAssembly().Location;
            _dirPath = Path.GetDirectoryName(_dirPath);
            _binaryFormatter = new BinaryFormatter();
            if (_dirPath != null)
            {
                _dirPath = Path.Combine(_dirPath, "Rating");

                if (!Directory.Exists(_dirPath))
                {
                    Directory.CreateDirectory(_dirPath);
                }
                _filePath = Path.Combine(_dirPath, "top.dat");
            }
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fs.Length != 0)
                {
                    Top = (List<StatisticItemHolder>) _binaryFormatter.Deserialize(fs);
                }
                else
                {
                    Top = new List<StatisticItemHolder>();
                }
            }
        }

        #endregion

        #region Public Methods

        public void AddStatistic(string name, int score)
        {
            Top.Add(new StatisticItemHolder(name, score));
            using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                Top.Sort(delegate(StatisticItemHolder x, StatisticItemHolder y)
                {
                    if (x.Score < y.Score)
                    {
                        return 1;
                    }
                    else if (x.Score == y.Score)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                });
                _binaryFormatter.Serialize(fs, Top);
            }
        }
        public void Clear()
        {
            Top.Clear();
        }

        #endregion
    }
}

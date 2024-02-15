using System;

namespace laba2_2sem
{
    class Document
    {
        public string Name;
        public string AuthorName;
        public string Keywords;
        public string Theme;
        public string Path;

        public Document(string name, string authorName, string keywords, string theme, string path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
        }

        virtual public string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nkeywords: {this.Keywords}\nheme: {this.Theme}\npath: {this.Path}";
        }
    }

    class MSWord : Document
    {
        public string Font;

        public MSWord(string name, string authorName, string keywords, string theme, string path, string font) : base(name, authorName, keywords, theme, path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
            this.Font = font;
        }

        public override string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nkeywords: {this.Keywords}\ntheme: {this.Theme}\npath: {this.Path}\nfont: {this.Font}";
        }
    }

    class PDF : Document
    {
        public int PagesCount;

        public PDF(string name, string authorName, string keywords, string theme, string path, int pagesCount) : base(name, authorName, keywords, theme, path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
            this.PagesCount = pagesCount;
        }

        public override string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nmkeywords: {this.Keywords}\ntheme: {this.Theme}\npath: {this.Path}\npages count: {this.PagesCount}";
        }
    }

    class MSExcel : Document
    {
        public int RowsCount;
        public int ColumnsCount;

        public MSExcel(string name, string authorName, string keywords, string theme, string path, int rowsCount, int columnsCount) : base(name, authorName, keywords, theme, path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
            this.RowsCount = rowsCount;
            this.ColumnsCount = columnsCount;
        }

        public override string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nkeywords: {this.Keywords}\ntheme: {this.Theme}\npath: {this.Path}\nrows: {this.RowsCount}\ncolumns: {this.ColumnsCount}";
        }
    }

    class TXT : Document
    {
        public string Encoding;

        public TXT(string name, string authorName, string keywords, string theme, string path, string encoding) : base(name, authorName, keywords, theme, path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
            this.Encoding = encoding;
        }

        public override string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nkeywords: {this.Keywords}\ntheme: {this.Theme}\npath: {this.Path}\nencoding: {this.Encoding}";
        }
    }

    class HTML : Document
    {
        public string Title;

        public HTML(string name, string authorName, string keywords, string theme, string path, string title) : base(name, authorName, keywords, theme, path)
        {
            this.Name = name;
            this.AuthorName = authorName;
            this.Keywords = keywords;
            this.Theme = theme;
            this.Path = path;
            this.Title = title;
        }

        public override string GetInfo()
        {
            return $"name: {this.Name}\nauthor: {this.AuthorName}\nkeywords: {this.Keywords}\ntheme: {this.Theme}\npath: {this.Path}\ntitle: {this.Title}";
        }
    }

    class Singleton
    {
        public static Singleton instance;
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        public void ShowInfo(Document currentDocument)
        {
            Console.WriteLine(currentDocument.GetInfo(), "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            bool isGameOver = false;

            Console.WriteLine("1) MSWord\n2) PDF\n3) MSExcel\n4) TXT\n5) HTML");

            userChoice = Convert.ToInt32(Console.ReadLine());

            while (!isGameOver)
            {
                Console.Clear();

                Singleton manager = new Singleton();

                switch (userChoice)
                {
                    case 1:
                        {
                            MSWord file = new MSWord
                            (
                                "WordFile.word",
                                "File's author",
                                "key, word",
                                "animals",
                                "C:\\Users\\me\\WordFile.word",
                                "Times new roman"
                            );
                            manager.ShowInfo(file);
                            break;
                        }
                    case 2:
                        {
                            PDF file = new PDF
                            (
                                "PDFFile.pdf",
                                "File's author",
                                "key, PDF",
                                "animals",
                                "C:\\Users\\me\\PDFFile.pdf",
                                7
                            );
                            manager.ShowInfo(file);
                            break;
                        }
                    case 3:
                        {
                            MSExcel file = new MSExcel
                            (
                                "MSExcelFile.xlsx",
                                "File's author",
                                "key, excel",
                                "animals",
                                "C:\\Users\\me\\MSExcelFile.xlsx",
                                7,
                                3
                            );
                            manager.ShowInfo(file);
                            break;
                        }
                    case 4:
                        {
                            TXT file = new TXT
                            (
                                "TXTFile.txt",
                                "File's author",
                                "key, txt",
                                "animals",
                                "C:\\Users\\me\\TXTFile.txt",
                                "UTF-16"
                            );
                            manager.ShowInfo(file);
                            break;
                        }
                    case 5:
                        {
                            HTML file = new HTML
                            (
                                "HTMLFile.html",
                                "File's author",
                                "key, html",
                                "animals",
                                "C:\\Users\\me\\HTMLFile.html",
                                "Landing page"
                            );
                            manager.ShowInfo(file);
                            break;
                        }
                }

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    if (userChoice == 1)
                    {
                        userChoice = 5;
                    }
                    else
                    {
                        --userChoice;
                    }
                } 
                else if (key == ConsoleKey.RightArrow)
                {
                    if (userChoice == 5)
                    {
                        userChoice = 1;
                    }
                    else
                    {
                        ++userChoice;
                    }
                }
                else if(key == ConsoleKey.Escape)
                {
                    isGameOver = true;
                }
            }
        }
    }
}

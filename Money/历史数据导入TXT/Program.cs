using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Dos.ORM;

namespace 历史数据导入TXT
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\Money\2015.txt";

            string[] txt = File.ReadAllLines(path);
            List<string> list = txt.Reverse().ToList();

            DbSession session = DB.Context;
            foreach (string s in list)
            {
                if (s.Length <= 0) continue;

                string[] line = s.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string phase = line[0];

                string[] ball = line[1].Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries);

                string redBall1 = ball[0];
                string redBall2 = ball[1];
                string redBall3 = ball[2];
                string redBall4 = ball[3];
                string redBall5 = ball[4];
                string redBall6 = ball[5];

                string blueBall = ball[6];

                string lotteryDate = line[2];

                string insertDate = DateTime.Now.ToShortDateString();


                //var list = DB.Context.From<Dos.Model.TableName>().ToList();
                Money money = new Money();
                money.Phase = phase;
                money.RedBall1 = redBall1;
                money.RedBall2 = redBall2;
                money.RedBall3 = redBall3;
                money.RedBall4 = redBall4;
                money.RedBall5 = redBall5;
                money.RedBall6 = redBall6;
                money.BlueBall = blueBall;
                money.LotteryDate = lotteryDate;
                money.InsertDate = insertDate;

                int i = session.Insert(money);

                Console.WriteLine(phase);
            }
            Console.WriteLine("完成");
            Console.ReadKey();
        }
    }

    public class DB
    {
        public static readonly DbSession Context = new DbSession("DosConn");
      
    }
    /// <summary>
    /// 实体类Money。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    //[Table("money")]
    [Serializable]
    public partial class Money : Entity
    {
        public Money()
            : base("Money")
        {

        }

        #region Model
        private int _ID;
        private string _Phase;
        private string _RedBall1;
        private string _RedBall2;
        private string _RedBall3;
        private string _RedBall4;
        private string _RedBall5;
        private string _RedBall6;
        private string _BlueBall;
        private string _LotteryDate;
        private string _InsertDate;

        /// <summary>
        /// 
        /// </summary>
        [Field("ID")]
        public int ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange("ID");
                this._ID = value;
            }
        }
        /// <summary>
        /// 期数
        /// </summary>
        [Field("Phase")]
        public string Phase
        {
            get { return _Phase; }
            set
            {
                this.OnPropertyValueChange("Phase");
                this._Phase = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall1")]
        public string RedBall1
        {
            get { return _RedBall1; }
            set
            {
                this.OnPropertyValueChange("RedBall1");
                this._RedBall1 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall2")]
        public string RedBall2
        {
            get { return _RedBall2; }
            set
            {
                this.OnPropertyValueChange("RedBall2");
                this._RedBall2 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall3")]
        public string RedBall3
        {
            get { return _RedBall3; }
            set
            {
                this.OnPropertyValueChange("RedBall3");
                this._RedBall3 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall4")]
        public string RedBall4
        {
            get { return _RedBall4; }
            set
            {
                this.OnPropertyValueChange("RedBall4");
                this._RedBall4 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall5")]
        public string RedBall5
        {
            get { return _RedBall5; }
            set
            {
                this.OnPropertyValueChange("RedBall5");
                this._RedBall5 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("RedBall6")]
        public string RedBall6
        {
            get { return _RedBall6; }
            set
            {
                this.OnPropertyValueChange("RedBall6");
                this._RedBall6 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("BlueBall")]
        public string BlueBall
        {
            get { return _BlueBall; }
            set
            {
                this.OnPropertyValueChange("BlueBall");
                this._BlueBall = value;
            }
        }
        /// <summary>
        /// 开奖日期
        /// </summary>
        [Field("LotteryDate")]
        public string LotteryDate
        {
            get { return _LotteryDate; }
            set
            {
                this.OnPropertyValueChange("LotteryDate");
                this._LotteryDate = value;
            }
        }
        /// <summary>
        /// 插入日期
        /// </summary>
        [Field("InsertDate")]
        public string InsertDate
        {
            get { return _InsertDate; }
            set
            {
                this.OnPropertyValueChange("InsertDate");
                this._InsertDate = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.ID,
			};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.Phase,
				_.RedBall1,
				_.RedBall2,
				_.RedBall3,
				_.RedBall4,
				_.RedBall5,
				_.RedBall6,
				_.BlueBall,
				_.LotteryDate,
				_.InsertDate,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._Phase,
				this._RedBall1,
				this._RedBall2,
				this._RedBall3,
				this._RedBall4,
				this._RedBall5,
				this._RedBall6,
				this._BlueBall,
				this._LotteryDate,
				this._InsertDate,
			};
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "money");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "money", "");
            /// <summary>
            /// 期数
            /// </summary>
            public readonly static Field Phase = new Field("Phase", "money", "期数");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall1 = new Field("RedBall1", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall2 = new Field("RedBall2", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall3 = new Field("RedBall3", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall4 = new Field("RedBall4", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall5 = new Field("RedBall5", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RedBall6 = new Field("RedBall6", "money", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BlueBall = new Field("BlueBall", "money", "");
            /// <summary>
            /// 开奖日期
            /// </summary>
            public readonly static Field LotteryDate = new Field("LotteryDate", "money", "开奖日期");
            /// <summary>
            /// 插入日期
            /// </summary>
            public readonly static Field InsertDate = new Field("InsertDate", "money", "插入日期");
        }
        #endregion
    }

}

using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //VidoLessonInfo
    public partial class VidoLessonInfoManage
    {

        private readonly VidoLessonInfoService dal = new VidoLessonInfoService();
        private VidoLessonInfoManage()
        { }

        public static VidoLessonInfoManage GetInstance()
        {
            return new VidoLessonInfoManage();
        }

        #region 自定义方法



        #endregion

        #region  Method

        /// <summary>
        /// 分页查询
        /// </summary>
        public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        {
            return dal.GetPageList(pageSize, pageIndex, strWhere, fdlOrder, isCount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string VL_ID)
        {
            return dal.Exists(VL_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(VidoLessonInfo model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(VidoLessonInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string VL_ID)
        {

            return dal.Delete(VL_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public VidoLessonInfo GetModel(string VL_ID)
        {

            return dal.GetModel(VL_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public VidoLessonInfo GetModelByCache(string VL_ID)
        {

            string CacheKey = "VidoLessonInfoModel-" + VL_ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(VL_ID);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (VidoLessonInfo)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<VidoLessonInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<VidoLessonInfo> DataTableToList(DataTable dt)
        {
            List<VidoLessonInfo> modelList = new List<VidoLessonInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                VidoLessonInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new VidoLessonInfo();
                    model.VL_ID = dt.Rows[n]["VL_ID"].ToString();
                    model.V_ID = dt.Rows[n]["V_ID"].ToString();
                    model.VL_Name = dt.Rows[n]["VL_Name"].ToString();
                    model.VL_Vido = dt.Rows[n]["VL_Vido"].ToString();
                    model.VL_SmallImg = dt.Rows[n]["VL_SmallImg"].ToString();
                    model.VL_BigImg = dt.Rows[n]["VL_BigImg"].ToString();
                    model.VL_Length = dt.Rows[n]["VL_Length"].ToString();
                    if (dt.Rows[n]["VL_Order"].ToString() != "")
                    {
                        model.VL_Order = int.Parse(dt.Rows[n]["VL_Order"].ToString());
                    }
                    if (dt.Rows[n]["VL_Time"].ToString() != "")
                    {
                        model.VL_Time = DateTime.Parse(dt.Rows[n]["VL_Time"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}
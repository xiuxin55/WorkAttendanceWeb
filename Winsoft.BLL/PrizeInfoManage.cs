using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Winsoft.Common;
using Winsoft.DAL;
using Winsoft.Model;
namespace Winsoft.BLL
{
    //MemberInfo
    public partial class PrizeInfoManage
    {

        private readonly PrizeInfoService dal = new PrizeInfoService();
        private PrizeInfoManage()
        { }

        public static PrizeInfoManage GetInstance()
        {
            return new PrizeInfoManage();
        }
        public bool UpdateAllocate(List<PrizeAllocateModel> list)
        {
            return dal.UpdateAllocate(list);
        }
        public List<WebSiteModel> GetWebsiteList(DataSet ds)
        {
            List<WebSiteModel> WebSiteModelList = new List<WebSiteModel>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    WebSiteModel wm = new WebSiteModel();
                    wm.WebsiteID = item["WebsiteID"].ToString();
                    wm.WebsiteName = item["WebsiteName"].ToString();
                    wm.WebsiteFlag = item["WebsiteFlag"].ToString();
                    wm.WebsiteType = item["WebsiteType"].ToString();
                    WebSiteModelList.Add(wm);
                }
              
            }
            return WebSiteModelList;
        }
        #region 自定义方法

        //public bool Login(string M_Username, string M_Password)
        //{
        //    return dal.Login(M_Username, M_Password);
        //}

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public PrizeInfo GetModelByVerificationCode(string M_VerificationCode)
        //{
        //    return dal.GetModelByVerificationCode(M_VerificationCode);
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PrizeInfo GetModelByName(string P_Name)
        {
            return dal.GetModelByName(P_Name);
        }

        #endregion

        #region  Method

        ///// <summary>
        ///// 分页查询
        ///// </summary>
        //public DataTable GetPageList(int pageSize, int pageIndex, string strWhere, string fdlOrder, int isCount)
        //{
        //    return dal.GetPageList(pageSize, pageIndex, strWhere, fdlOrder, isCount);
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string guid)
        {
            return dal.Exists(guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(PrizeAllocateModel model)
        {
            return dal.Add(model);

        }
        public bool Add(List<PrizeAllocateModel> model, PrizeInfo prize)
        {
            return dal.Add(model, prize);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update( PrizeInfo prize)
        {
            return dal.Update( prize);
        }
        public List<PrizeInfo> GetPrizeInfo(PrizeInfo prize)
        {
            return dal.GetPrizeInfo(prize);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PrizeID)
        {

            return dal.DeletePrizeId(PrizeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PrizeInfo GetModel(string PrizeID)
        {
            return dal.GetModel(PrizeID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PrizeInfo GetModelByCache(string P_Id)
        {

            string CacheKey = "Prize-" + P_Id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(P_Id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (PrizeInfo)objModel;
        }

        public List<PrizeAllocateModel>  GetAllPrize(string id)
        {
            DataTable dt=dal.GetAllPrize(id);
            List<PrizeAllocateModel> list = new List<PrizeAllocateModel>();
            foreach (DataRow item in dt.Rows )
            {
                PrizeAllocateModel pam = new PrizeAllocateModel();
                pam.PrizeID = item["PrizeID"].ToString();
                pam.PrizeName = item["PrizeName"].ToString();
                pam.PrizeScore = item["PrizeScore"].ToString();
                pam.PrizeCount = int.Parse(item["PrizeCount"].ToString());
                pam.WebsiteID = item["WebsiteID"].ToString();
                pam.WebsiteName = item["WebsiteName"].ToString();
                pam.PrizeAmount = int.Parse( item["PrizeAmount"].ToString());
                pam.PrizeUsedAmount = pam.PrizeAmount - pam.PrizeCount;
                list.Add(pam);
            }
            return list;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetListNotAllocateWebsite(string prizeid)
        {
            return dal.GetListNotAllocateWebsite(prizeid);
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
        public List<PrizeInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PrizeInfo> DataTableToList(DataTable dt)
        {
            List<PrizeInfo> modelList = new List<PrizeInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PrizeInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PrizeInfo();
                    //model.M_ID = dt.Rows[n]["M_ID"].ToString();
                    //model.M_Address = dt.Rows[n]["M_Address"].ToString();
                    //model.M_Like = dt.Rows[n]["M_Like"].ToString();
                    //model.M_About = dt.Rows[n]["M_About"].ToString();
                    //if (dt.Rows[n]["M_Points"].ToString() != "")
                    //{
                    //    model.M_Points = decimal.Parse(dt.Rows[n]["M_Points"].ToString());
                    //}
                    //if (dt.Rows[n]["M_Time"].ToString() != "")
                    //{
                    //    model.M_Time = DateTime.Parse(dt.Rows[n]["M_Time"].ToString());
                    //}
                    //model.M_IsVerify = dt.Rows[n]["M_IsVerify"].ToString();
                    //model.M_VerificationCode = dt.Rows[n]["M_VerificationCode"].ToString();
                    //model.M_Username = dt.Rows[n]["M_Username"].ToString();
                    //model.M_Password = dt.Rows[n]["M_Password"].ToString();
                    //model.M_EMail = dt.Rows[n]["M_EMail"].ToString();
                    //model.M_Name = dt.Rows[n]["M_Name"].ToString();
                    //model.M_Nickname = dt.Rows[n]["M_Nickname"].ToString();
                    //model.M_Img = dt.Rows[n]["M_Img"].ToString();
                    //model.M_Sex = dt.Rows[n]["M_Sex"].ToString();
                    //model.M_Tel = dt.Rows[n]["M_Tel"].ToString();
                    //model.P_Id = Convert.ToInt32(dt.Rows[n]["P_Id"].ToString());
                    //model.P_UserId = Convert.ToInt32(dt.Rows[n]["P_UserId"].ToString());
                    //model.P_CityId = dt.Rows[n]["P_CityId"].ToString();
                    //model.P_ProvinceId = dt.Rows[n]["P_ProvinceId"].ToString();
                    //model.P_Name = dt.Rows[n]["P_Name"].ToString();
                    //model.P_Activity = Convert.ToInt32(dt.Rows[n]["P_Activity"].ToString());
                    //model.P_Integral = Convert.ToInt32(dt.Rows[n]["P_Integral"].ToString());


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
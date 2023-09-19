using IIITS.JUNCTIONDB.DAL;
using Oracle.ManagedDataAccess.Client;
using System.Data;
namespace CountryMasterForm.Models
{
    public class Category
    {
        #region Variables
        public int categoryid { get; set; }
        public string? categoryname { get; set; }
        public string? description { get; set; }
        public int responsecode { get; set; }
        public string? responseMessage { get; set; }
        #endregion
        public int  isActive { get; set; }
        #region Lists
        public List<Category> lstdt = new List<Category>();
        #endregion

        /// <summary>
        /// Save to Database/Update data to Database
        /// </summary>
        /// <param name="objDetails"></param>
        /// <returns></returns>
        public int SaveOrUpdateDetails(Category objDetails)
        {
            try
            {
                CustOledbConnection objcon = new CustOledbConnection("IIITS", "C:\\Users\\goneppa.gk\\Documents\\CountryMasterForm\\CountryMasterForm\\CountryMasterForm\\constring.json");
                objcon.proc_name = "CATEGORY_MASTER_SAVE_UPDATE_DETAILS";
                objcon.dtInputParameter.Rows.Add("C_CATEGORY_ID", Convert.ToInt32(objDetails.categoryid), "INPUT");
                objcon.dtInputParameter.Rows.Add("C_CATEGORY_NAME", objDetails.categoryname, "INPUT");
                objcon.dtInputParameter.Rows.Add("C_REMARK", objDetails.description, "INPUT");
                objcon.dtInputParameter.Rows.Add("OUT_ID", responsecode, "OUTPUT");
                objcon.ArrInputType[0] = OracleDbType.Int32;
                objcon.ArrInputType[1] = OracleDbType.Varchar2;
                objcon.ArrInputType[2] = OracleDbType.Varchar2;
                objcon.ArrInputType[3] = OracleDbType.Int32;
                string[] arr = objcon.Execute(objcon);
                responsecode = Convert.ToInt32(arr[0]);
                return responsecode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetch DataTable
        /// </summary>
        /// <returns></returns>
        public List<Category> FetchCategorydt()
        {
            try
            {
                DataTable dt = new DataTable();
                CustOledbConnection objcon = new CustOledbConnection("IIITS", "C:\\Users\\goneppa.gk\\Documents\\CountryMasterForm\\CountryMasterForm\\CountryMasterForm\\constring.json");
                objcon.proc_name = "FETCH_CATEGORY_TABLE";
                objcon.dtInputParameter.Rows.Add("PROC_OUTPUT", "", "OUTPUT");
                objcon.ArrInputType[0] = OracleDbType.RefCursor;
                dt = objcon.FetchDataTable(objcon);
                if (dt.Rows.Count > 0)
                {
                    lstdt = (from dr in dt.AsEnumerable()
                             select new Category()
                             {
                                 categoryid = Convert.ToInt32(dr["CATEGORY_ID"]),
                                 categoryname = Convert.ToString(dr["CATEGORY_NAME"]),
                                 description = Convert.ToString(dr["REMARK"]),
                                 isActive = Convert.ToInt32(dr["IS_ACTIVE"]),
                             }).ToList();
                }
                return lstdt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

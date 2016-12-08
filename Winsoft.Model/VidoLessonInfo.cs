using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    //VidoLessonInfo
    public class VidoLessonInfo
    {

        /// <summary>
        /// VL_ID
        /// </summary>		
        private string _vl_id;
        public string VL_ID
        {
            get { return _vl_id; }
            set { _vl_id = value; }
        }
        /// <summary>
        /// V_ID
        /// </summary>		
        private string _v_id;
        public string V_ID
        {
            get { return _v_id; }
            set { _v_id = value; }
        }
        /// <summary>
        /// VL_Name
        /// </summary>		
        private string _vl_name;
        public string VL_Name
        {
            get { return _vl_name; }
            set { _vl_name = value; }
        }
        /// <summary>
        /// VL_Vido
        /// </summary>		
        private string _vl_vido;
        public string VL_Vido
        {
            get { return _vl_vido; }
            set { _vl_vido = value; }
        }
        /// <summary>
        /// VL_SmallImg
        /// </summary>		
        private string _vl_smallimg;
        public string VL_SmallImg
        {
            get { return _vl_smallimg; }
            set { _vl_smallimg = value; }
        }
        /// <summary>
        /// VL_BigImg
        /// </summary>		
        private string _vl_bigimg;
        public string VL_BigImg
        {
            get { return _vl_bigimg; }
            set { _vl_bigimg = value; }
        }
        /// <summary>
        /// VL_Length
        /// </summary>		
        private string _vl_length;
        public string VL_Length
        {
            get { return _vl_length; }
            set { _vl_length = value; }
        }
        /// <summary>
        /// VL_Order
        /// </summary>		
        private int _vl_order;
        public int VL_Order
        {
            get { return _vl_order; }
            set { _vl_order = value; }
        }
        /// <summary>
        /// VL_Time
        /// </summary>		
        private DateTime _vl_time;
        public DateTime VL_Time
        {
            get { return _vl_time; }
            set { _vl_time = value; }
        }

    }
}
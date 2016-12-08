using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Winsoft.Model
{
    //OrderInfo
    public class OrderInfo
    {

        /// <summary>
        /// O_ID
        /// </summary>		
        private string _o_id;
        public string O_ID
        {
            get { return _o_id; }
            set { _o_id = value; }
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
        /// M_ID
        /// </summary>		
        private string _m_id;
        public string M_ID
        {
            get { return _m_id; }
            set { _m_id = value; }
        }
        /// <summary>
        /// O_Serial
        /// </summary>		
        private string _o_serial;
        public string O_Serial
        {
            get { return _o_serial; }
            set { _o_serial = value; }
        }
        /// <summary>
        /// O_Order
        /// </summary>		
        private string _o_order;
        public string O_Order
        {
            get { return _o_order; }
            set { _o_order = value; }
        }
        /// <summary>
        /// O_Price
        /// </summary>		
        private decimal _o_price;
        public decimal O_Price
        {
            get { return _o_price; }
            set { _o_price = value; }
        }
        /// <summary>
        /// O_Status
        /// </summary>		
        private string _o_status;
        public string O_Status
        {
            get { return _o_status; }
            set { _o_status = value; }
        }
        /// <summary>
        /// O_NextTime
        /// </summary>		
        private string _o_nexttime;
        public string O_NextTime
        {
            get { return _o_nexttime; }
            set { _o_nexttime = value; }
        }
        /// <summary>
        /// O_PaymentTime
        /// </summary>		
        private string _o_paymenttime;
        public string O_PaymentTime
        {
            get { return _o_paymenttime; }
            set { _o_paymenttime = value; }
        }
        /// <summary>
        /// O_Time
        /// </summary>		
        private DateTime _o_time;
        public DateTime O_Time
        {
            get { return _o_time; }
            set { _o_time = value; }
        }

    }
}
using System.Diagnostics;

namespace DeviceRental.Common
{
    public static class Common
    {
        public static string Success = "Data was changed";
        public static string Failed = "Data can not be changed";

        /// <summary>
        /// Get current method
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().DeclaringType.FullName;
        }
    }
}

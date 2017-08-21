//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SpecFlowDemo.PageObjects
//{
//    class HolidaysPage : BasePageObject
//    {

//        public HolidaysPage(IWebDriver driver) : base(driver) { }

//        static SparseArray<List<Integer>> holidays = new SparseArray<List<Integer>>();
//        static class GetHoliDay : AsyncTask<Void, Void, Void> {


//        int year;
//        GetHoliDay(int year)
//        {
//            this.year = year;
//            holidays.clear();
//            for (int i = 0; i < 12; i++)
//            {
//                holidays.put(i, new ArrayList<Integer>());
//            }
//        }

//           public void doInBackground(DateTime date)
//        {
//            try
//            {
//                    var year = date.DayOfWeek;
//                    var json = new WebClient().DownloadString("https://www.timeanddate.com/holidays/ukraine/" + year);

//                Pattern p = Pattern.compile("class=\"nw\">(.*?)</td>");
//                Matcher m = p.matcher(json);
//                while (m.find())
//                {
//                    String dateF = m.group(1) + " " + year;
//                    Date date = (Date)new SimpleDateFormat("LLL d yyyy", Locale.ENGLISH).parse(dateF);
//                    long dateLong = date.getTime();

//                    Calendar c = Calendar.getInstance();
//                    c.setTimeInMillis(dateLong);
//                    List<Integer> listInteger = holidays.get(c.get(Calendar.MONTH));
//                    listInteger.add(c.get(Calendar.DAY_OF_MONTH));
//                }




//            }
//            catch (Exception e) { }
//            return null;
//        }

//        @Override
//        public void onPostExecute(Void par)
//        {
//            // Проставляем праздничные дни

//        }

//    }
//}
//}








////original


////2
////3
////4
////5
////6
////7
////8
////9
////10
////11
////12
////13
////14
////15
////16
////17
////18
////19
////20
////21
////22
////23
////24
////25
////26
////27
////28
////29
////30
////31
//32
//33
//34
//35
//36
//37
//38
//39
//40
//41
//42
//43
//44
//45
//46
//47
//48
//49
//50
//static SparseArray<List<Integer>> holidays = new SparseArray<List<Integer>>();
//static class GetHoliDay extends AsyncTask<Void, Void, Void> {

//        int year;
//    GetHoliDay(int year) {
//        this.year = year;
//        holidays.clear();
//        for (int i = 0; i < 12; i++)
//        {
//            holidays.put(i, new ArrayList<Integer>());
//        }
//    }

//    @Override
//        protected Void doInBackground(Void... params)
//{
//    try
//    {
//        String region = Locale.getDefault().getDisplayCountry(Locale.ENGLISH).toLowerCase(Locale.ENGLISH);
//        String html = Internet.getJSON(ac, "http://www.timeanddate.com/holidays/" + region + "/" + year);

//        Pattern p = Pattern.compile("class=\"nw\">(.*?)</td>");
//        Matcher m = p.matcher(html);
//        while (m.find())
//        {
//            String dateF = m.group(1) + " " + year;
//            Date date = (Date)new SimpleDateFormat("LLL d yyyy", Locale.ENGLISH).parse(dateF);
//            long dateLong = date.getTime();

//            Calendar c = Calendar.getInstance();
//            c.setTimeInMillis(dateLong);
//            List<Integer> listInteger = holidays.get(c.get(Calendar.MONTH));
//            listInteger.add(c.get(Calendar.DAY_OF_MONTH));
//        }

//        c.setTimeInMillis(System.currentTimeMillis());

//        for (int i = 0; i < 12; i++)
//        {
//            List<Integer> listInteger = holidays.get(i);
//            for (Integer integ : listInteger)
//            {
//                Log.i("holidays", i + ", " + integ.toString());
//            }
//        }
//    }
//    catch (Exception e) { }
//    return null;
//}

////@Override
////        public void onPostExecute(Void par)
////{
////    // Проставляем праздничные дни

////}

////    }
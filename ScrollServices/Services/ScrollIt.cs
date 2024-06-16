using ScrollServices.Interface;

namespace ScrollServices.Services
{
    public class ScrollIt: IScrolling
    {
        public string errorMsg {  get; set; }   
        public ScrollIt()
        {
                
        }
        public async Task<List<int>> GetInts(int start, int count, string scrollType)
        {
            List<int> ints = new List<int>();
            int cnt = start;
            int increment = 0;
            if (start < 0)
            {
                errorMsg = "Invalid start value";
                await Message();
                ints.Add(increment);
                return await Task.FromResult(ints);
            }else 
            {
                errorMsg = "";
                await Message();
            }
            for (int i = start; i < Math.Abs( start + count); i++)
            { 
                if (scrollType == ">>")
                {
                    cnt++;
                }
                if (scrollType == "<<")
                {
                    if (start == 0 || start<count)
                    {
                        continue;
                    }
                    cnt--;
                }
               
                //start = start + cnt;
               // ints.Add(i);
            }
            increment = cnt ;
            ints.Add(increment);
            return await Task.FromResult( ints);
        }

        public async Task<string> Message()
        {

            return await Task.FromResult(errorMsg);
        }


    }
}

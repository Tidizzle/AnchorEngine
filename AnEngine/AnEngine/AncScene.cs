using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnEngine
{
    public abstract class AncScene
    {
        private string sceneName;
        public string SceneName
        {
            get
            {
                return sceneName;
            }

            set
            {
                sceneName = value;
            }
        }

        public  List<AncObject> ObjList;


        public AncScene(string Scenename)
        {
            SceneName = Scenename;
        }

        public virtual void UpdateObjs()
        {
            foreach(var obj in ObjList)
            {
                
            }
        }
    }
}

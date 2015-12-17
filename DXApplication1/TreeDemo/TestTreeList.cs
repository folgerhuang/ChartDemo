using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    class TestTreeList
    {
        //名称字段变量
        private string m_sName = string.Empty;
        //选择字段变量
        private bool m_bIsChecked = false;
        //子Node节点ID变量
        private int m_iID = -1;
        //父Node节点ID变量
        private int m_iParentID = -1;

        public int ID
        {
            get
            {
                return m_iID;
            }
            set
            {
                m_iID = value;
            }
        }

        public int ParentID
        {
            get
            {

                return m_iParentID;

            }
            set
            {

                m_iParentID = value;

            }
        }

        public string Name
        {
            get
            {

                return m_sName;

            }

            set
            {

                m_sName = value;

            }

        }



        public bool IsChecked
        {

            get
            {

                return m_bIsChecked;

            }

            set
            {

                m_bIsChecked = value;

            }

        }

    }

}

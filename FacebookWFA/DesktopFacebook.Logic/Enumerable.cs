using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.Logic
{
    public class Enumerable<T> : IEnumerable<T>
        where T : class
    {
        private List<T> m_ListOfT;

        public Enumerable(List<T> i_ListOfT)
        {
            m_ListOfT = i_ListOfT;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Iterator<T> : IEnumerator<T>
            where T : class
        {
            private Enumerable<T> m_Aggregate;
            private int m_CurrentIdx = -1;
            private int m_Count = -1;

            public Iterator(Enumerable<T> i_Collection)
            {
                m_Aggregate = i_Collection;
                m_Count = m_Aggregate.m_ListOfT.Count;
            }

            public T Current
            {
                get
                {
                    return m_Aggregate.m_ListOfT[m_CurrentIdx];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                if (m_Aggregate.m_ListOfT != null)
                {
                    m_Aggregate.m_ListOfT.Clear();
                }

                Reset();
            }

            public bool MoveNext()
            {
                if (m_Count != m_Aggregate.m_ListOfT.Count)
                {
                    throw new Exception("Collection can not be changed during iteration!");
                }
                
                if (m_CurrentIdx >= m_Count)
                {
                    throw new Exception("Already reached the end of the collection");
                }

                return ++m_CurrentIdx < m_Aggregate.m_ListOfT.Count;
            }

            public void Reset()
            {
                m_CurrentIdx = -1;
            }
        }
    }
}

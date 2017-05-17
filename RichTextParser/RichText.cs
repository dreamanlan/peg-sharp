using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RichTextParser
{
    public enum RichTextType
    {
        Normal = 0,
        Hyper,
        UnusedHyper,
    }
    public interface IRichText
    {
        RichTextType Type { get; }
    }
    public class NormalText : IRichText
    {
        public RichTextType Type { get { return RichTextType.Normal; } }

        public string Text {
            get { return m_Text; }
            set { m_Text = value; }
        }

        private string m_Text = string.Empty;
    }
    public class HyperTextAttr
    {
        public string Key {
            get { return m_Key; }
            set { m_Key = value; }
        }
        public string Value {
            get { return m_Value; }
            set { m_Value = value; }
        }

        private string m_Key = string.Empty;
        private string m_Value = string.Empty;
    }
    public class HyperText : IRichText
    {
        public RichTextType Type { get { return RichTextType.Hyper; } }

        public string BeginTag {
            get {
                string ret = string.Empty;
                int ct = m_Attrs.Count;
                if (ct > 0) {
                    ret = m_Attrs[0].Key;
                }
                return ret;
            }
        }
        public string EndTag {
            get { return m_EndTag; }
            set { m_EndTag = value; }
        }
        public List<HyperTextAttr> Attrs {
            get { return m_Attrs; }
        }
        public List<IRichText> Texts {
            get { return m_Texts; }
        }

        private List<HyperTextAttr> m_Attrs = new List<HyperTextAttr>();
        private List<IRichText> m_Texts = new List<IRichText>();
        private string m_EndTag = string.Empty;
    }
    public class UnusedHyperText : IRichText
    {
        public RichTextType Type { get { return RichTextType.UnusedHyper; } }

        public string Text {
            get { return m_Text; }
            set { m_Text = value; }
        }
        public List<HyperTextAttr> Attrs {
            get { return m_Attrs; }
        }

        private string m_Text = string.Empty;
        private List<HyperTextAttr> m_Attrs = new List<HyperTextAttr>();
    }
    public class RichText
    {
        public List<IRichText> Texts {
            get { return m_Texts; }
        }

        private List<IRichText> m_Texts = new List<IRichText>();
    }
}

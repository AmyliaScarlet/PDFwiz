using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Customize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class FormComm
    {
        private static FormComm _instance;
        private Dictionary<string, Form> _forms = new Dictionary<string, Form>();
        private Queue<Message> _messageQueue = new Queue<Message>();

        public static FormComm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormComm();
                }
                return _instance;
            }
        }

        public void AddListenner(string formName, Form form)
        {
            _forms.Add(formName, form);
        }

        public void RemoveListenner(string formName)
        {
            _forms.Remove(formName);
        }

        public void SendMessage(string formName, string fromformName, string message)
        {
            _messageQueue.Enqueue(new Message { FormName = formName, FromFormName = fromformName, MessageText = message });
        }

        public void handleMessage()
        {
            if (_messageQueue.Count > 0)
            {
                Message message = _messageQueue.Dequeue();

                //form.Invoke(new Action(() => form.Text = message.MessageText));
                if (message.MessageText == "ApplicationStateChange")
                {
                    switch (ApplicationStateMachine.Instance.CurrentState())
                    {
                        case ApplicationState.onStart:
                            foreach (var item in _forms)
                            {
                                item.Value.Hide();
                            }
                            _forms["StartForm"].Hide();
                            break;
                        default:
                            _forms["StartForm"].Hide();
                            break;
                    }

                } 
                else if (message.MessageText == "ApplicationExit") 
                {
                    Application.Exit();
                }
                else
                {
                    Form form = _forms[message.FormName];
                    Form fform = _forms[message.FromFormName];

                }         
            }

            

        }
    }

    public class Message
    {
        public string FormName { get; set; }
        public string MessageText { get; set; }
        public string FromFormName { get; set; }
    }
}

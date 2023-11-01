using PDFwiz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Customize
{
    public class ApplicationStateMachine : IApplicationState
    {
        private static ApplicationStateMachine _instance;
        private ApplicationState _currentState;

        private ApplicationStateMachine()
        {
            _currentState = ApplicationState.onStart;
        }

        public static ApplicationStateMachine Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationStateMachine();
                }
                return _instance;
            }
        }
        public ApplicationState CurrentState() 
        {
            return _currentState;
        }

        public ApplicationState NextState()
        {
            switch (_currentState)
            {
                case ApplicationState.onStart:
                    return _currentState;
                case ApplicationState.onNew:
                    _currentState = ApplicationState.onStart;
                    break;
                case ApplicationState.onOpenWord:
                    _currentState = ApplicationState.onStart;
                    break;
                case ApplicationState.onOpenPdf:
                    _currentState = ApplicationState.onStart;
                    break;
                case ApplicationState.onOpenPdfw:
                    _currentState = ApplicationState.onStart;
                    break;
                case ApplicationState.onClose:
                    _currentState = ApplicationState.onStart;
                    break;
                default:
                    throw new ArgumentException("Invalid state");
            }
            FormComm.Instance.SendMessage("", "", "ApplicationStateChange");
            return _currentState;

        }
        public ApplicationState NextState(ApplicationState state)
        {
            switch (_currentState)
            {
                case ApplicationState.onStart:
                    break;
                case ApplicationState.onNew:
                    if (state != ApplicationState.onStart) 
                    {
                        throw new ArgumentException("State Err:"+ CurrentState() + " -> " + state);
                    }
                    return _currentState;
                case ApplicationState.onOpenWord:
                    if (state != ApplicationState.onStart)
                    {
                        throw new ArgumentException("State Err:" + CurrentState() + " -> " + state);
                    }
                    return _currentState;
                case ApplicationState.onOpenPdf:
                    if (state != ApplicationState.onStart)
                    {
                        throw new ArgumentException("State Err:" + CurrentState() + " -> " + state);
                    }
                    return _currentState;
                case ApplicationState.onOpenPdfw:
                    if (state != ApplicationState.onStart)
                    {
                        throw new ArgumentException("State Err:" + CurrentState() + " -> " + state);
                    }
                    return _currentState;
                default:
                    throw new ArgumentException("Invalid state");
            }
            _currentState = state;
            FormComm.Instance.SendMessage("", "", "ApplicationStateChange");
            return _currentState;

        }
    }
}

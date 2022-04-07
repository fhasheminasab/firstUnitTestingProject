using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstUnitTestingProject
{
    public class Greeting
    {
        List<string> _names;
        List<string> _shoutingNames;
        List<string> _LowerCaseNames;
        string _massage;


        public Greeting()
        {
            _init();
        }
        public Greeting(string name)
        {
            _init();
            _names.Add(name);
        }
        public Greeting(List<string> names)
        {
            _init();
            _names = names;
        }
        private void _init()
        {
            _names = new List<string>();
            _LowerCaseNames = new List<string>();
            _shoutingNames = new List<string>();
        }

        private void _setMassage()
        {
            if (_names.Count == 0) _massage = "Hello my friend!";
            else
            {
                _handleSplits();
                _handleShouting();
            }
        }

        private void _handleSplits()
        {
            string separator = ",";
            string skipper = "\"";
            int count = 100;
            List<string> names = new List<string>();
            foreach (string name in _names)
            {
                List<string> splitedNames = new List<string>();
                if (name.Contains(skipper))
                {
                    string isolatedName = name.Split("\"", count, StringSplitOptions.TrimEntries).ToList()[1];
                    names.Add(isolatedName);
                    continue;
                }
                splitedNames = name.Split(separator, count, StringSplitOptions.TrimEntries).ToList();
                foreach (string splitedName in splitedNames)
                {
                    names.Add(splitedName);
                }
            }
            _names = names;

        }

        private void _handleShouting()
        {
            List<int> EmptyPlacesInTheNamesArray = new List<int>();
            for (int i = 0; i < _names.Count; i++)
            {
                if (_names[i].ToUpper() == _names[i])
                {
                    _shoutingNames.Add(_names[i]);
                }
                else _LowerCaseNames.Add(_names[i]);
            }
            _massage = "";
            if (_LowerCaseNames.Count > 0)
                _massage += _DontShout();
            if (_shoutingNames.Count > 0)
                _massage += _Shout();
        }

        private string _handlemultipleNames(string massage, List<string> _names)
        {
            for (int i = 0; i < _names.Count - 1; i++)
            {
                massage += _names[i];
                if (i < _names.Count - 2)
                    massage += ", ";
                else massage += " and ";

            }
            massage += _names[_names.Count - 1];
            return massage;
        }

        private string _DontShout()
        {
            string massage = "Hello ";
            if (_names.Count == 1) massage += _LowerCaseNames[0];
            else massage = _handlemultipleNames(massage, _LowerCaseNames);
            massage += ".";
            return massage;
        }
        private string _Shout()
        {
            string massage = "";

            if (_names.Count == 1)
            {
                massage += "HELLO ";
                massage += _shoutingNames[0];
            }
            else
            {
                massage += " AND HELLO ";
                massage = _handlemultipleNames(massage, _shoutingNames);
            }
            massage += "!!";

            return massage;
        }

        public string GreetThem()
        {
            _setMassage();
            return _massage;
            //return ("HELLO " + _names[0] + "!!");
        }


    }
}

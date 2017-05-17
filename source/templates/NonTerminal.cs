	// RULE-COMMENT
	private State METHOD-NAME(State _state, List<Result> _outResults)
	{
		int _startIndex = _state.Index;
		List<Result> results = new List<Result>();          // {{(not has-pass-action or pass-action-uses-results) and value != 'void' or value == 'XmlNode'}}
        List<Result> results = null;                        // {{has-pass-action and (pass-action-uses-text or not pass-action-uses-results) and value != 'XmlNode' or value == 'void'}}
        Console.WriteLine("RULE-NAME");			            // {{debugging}}
		
		string fail = null;								    // {{has-prolog and (prolog-uses-fail or pass-epilog-uses-fail)}}
		/* PROLOG-HOOK */							        // {{has-prolog}}
		if (fail != null)									// {{has-prolog and prolog-uses-fail}}
		{													// {{has-prolog and prolog-uses-fail}}
			DoDebugFailure(_startIndex, "'DEBUG-NAME' failed prolog");				// {{has-prolog and prolog-uses-fail and (debug == 'failures' or debug == 'both')}}
			return new State(_startIndex, false);		    // {{has-prolog and prolog-uses-fail}}
		}													// {{has-prolog and prolog-uses-fail}}
		
		/* RULE-BODY */
		
		if (_state.Parsed)								    // {{has-pass-epilog}}
			/* PASS-EPILOG-HOOK */					        // {{has-pass-epilog}}
		if (fail != null)								    // {{has-pass-epilog and pass-epilog-uses-fail}}
			_state = new State(_startIndex, false);	        // {{has-pass-epilog and pass-epilog-uses-fail}}
		
		if (_state.Parsed)
		{
			XmlElement _node = DoCreateElementNode("RULE-NAME", _startIndex, _state.Index - _startIndex, DoGetLine(_startIndex), DoGetCol(_startIndex), (from r in results where r.Value != null select r.Value).ToArray());	// {{value == 'XmlNode'}}
			_node.SetAttribute("alternative", "RULE-INDEX");							// {{value == 'XmlNode' and rule-has-alternatives}}
			VALUE value = _node;														// {{value == 'XmlNode'}}
			VALUE value = results.Count > 0 ? results[0].Value : default(VALUE);        // {{(not has-pass-action or pass-action-uses-results) and value != 'XmlNode' and value != 'void'}}
            VALUE value = default(VALUE);                                               // {{has-pass-action and (pass-action-uses-text or not pass-action-uses-results) and value != 'XmlNode' or value == 'void'}}
        
            string fatal = null;								                        // {{has-pass-action and pass-action-uses-fatal}}
			string text = m_input.Substring(_startIndex, _state.Index - _startIndex);	// {{has-pass-action and pass-action-uses-text}}
			
			/* PASS-ACTION */
			
			if (!string.IsNullOrEmpty(fatal))				// {{has-pass-action and pass-action-uses-fatal}}
				DoThrow(_startIndex, fatal);				// {{has-pass-action and pass-action-uses-fatal}}
			
			if (text != null && null != _outResults)																// {{has-pass-action and pass-action-uses-text}}
				_outResults.Add(new Result(this, _startIndex, _state.Index - _startIndex, m_input, ref value));	    // {{has-pass-action and pass-action-uses-text and value != 'void'}}
				_outResults.Add(new Result(this, _startIndex, _state.Index - _startIndex, m_input));			    // {{has-pass-action and pass-action-uses-text and value == 'void'}}
            if(null != _outResults)                                                                                 // {{(not has-pass-action or not pass-action-uses-text) and value != 'void'}}
                _outResults.Add(new Result(this, _startIndex, _state.Index - _startIndex, m_input, ref value));	    // {{(not has-pass-action or not pass-action-uses-text) and value != 'void'}}
			    _outResults.Add(new Result(this, _startIndex, _state.Index - _startIndex, m_input));				// {{(not has-pass-action or not pass-action-uses-text) and value == 'void'}}
		}
		else													// {{has-fail-action}}
		{														// {{has-fail-action}}
			string expected = null;						        // {{has-fail-action and fail-action-uses-expected}}
			
			/* FAIL-ACTION */
			
		}														// {{has-fail-action}}
		if (m_file == m_debugFile)																    // {{debugging and has-debug-file}}
		{																							// {{debugging and has-debug-file}}
			if (_state.Parsed)																		// {{(debug == 'matches' or debug == 'both') and has-debug-file}}
				DoDebugMatch(_startIndex, _state.Index, "'DEBUG-NAME' parsed");		                // {{(debug == 'matches' or debug == 'both') and has-debug-file}}
			if (!_state.Parsed)																		// {{(debug == 'failures' or debug == 'both') and has-debug-file}}
				DoDebugFailure(_startIndex, "'DEBUG-NAME' " + DoEscapeAll(_state.Errors.ToString()));	// {{(debug == 'failures' or debug == 'both') and has-debug-file}}
		}																								// {{debugging and has-debug-file}}
		if (_state.Parsed)																			    // {{(debug == 'matches' or debug == 'both') and not has-debug-file}}
			DoDebugMatch(_startIndex, _state.Index, "'DEBUG-NAME' parsed");			                    // {{(debug == 'matches' or debug == 'both') and not has-debug-file}}
		if (!_state.Parsed)																			    // {{(debug == 'failures' or debug == 'both') and not has-debug-file}}
			DoDebugFailure(_startIndex, "'DEBUG-NAME' " + DoEscapeAll(_state.Errors.ToString()));	    // {{(debug == 'failures' or debug == 'both') and not has-debug-file}}
		
		/* EPILOG-HOOK */
		
		if (!_state.Parsed)									// {{has-fail-epilog}}
			/* FAIL-EPILOG-HOOK */						    // {{has-fail-epilog}}

		return _state;
	}
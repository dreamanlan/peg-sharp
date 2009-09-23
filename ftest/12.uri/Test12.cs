// Machine generated by peg-sharp 0.3.261.0 from Test12.peg.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace FTest12
{
	[Serializable]
	internal sealed class ParserException : Exception
	{
		public ParserException()
		{
		}
		
		public ParserException(string message) : base(message)
		{
		}
		
		public ParserException(int line, int col, string file, string message) : base(string.Format("{0} at line {1} col {2}{3}", message, line, col, file != null ? (" in " + file) : "."))
		{
		}
		
		public ParserException(int line, int col, string file, string format, params object[] args) : this(line, col, file, string.Format(format, args))
		{
		}
		
		public ParserException(int line, int col, string file, string message, Exception inner) : base(string.Format("{0} at line {1} col {2}{3}", message, line, col, file != null ? (" in " + file) : "."), inner)
		{
		}
		
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		private ParserException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
	
	// Thread safe if Parser instances are not shared across threads.
	internal sealed partial class Test12
	{
		public Test12()
		{
			m_nonterminals.Add("uri", new ParseMethod[]{this.DoParseuriRule});
			m_nonterminals.Add("scheme", new ParseMethod[]{this.DoParseschemeRule});
			m_nonterminals.Add("hier-part", new ParseMethod[]{this.DoParsehier_partRule});
			m_nonterminals.Add("authority", new ParseMethod[]{this.DoParseauthorityRule});
			m_nonterminals.Add("userinfo", new ParseMethod[]{this.DoParseuserinfoRule});
			m_nonterminals.Add("host", new ParseMethod[]{this.DoParsehostRule});
			m_nonterminals.Add("port", new ParseMethod[]{this.DoParseportRule});
			m_nonterminals.Add("reg-name", new ParseMethod[]{this.DoParsereg_nameRule});
			m_nonterminals.Add("path-abempty", new ParseMethod[]{this.DoParsepath_abemptyRule});
			m_nonterminals.Add("segment", new ParseMethod[]{this.DoParsesegmentRule});
			m_nonterminals.Add("pchar", new ParseMethod[]{this.DoParsepcharRule});
			m_nonterminals.Add("unreserved", new ParseMethod[]{this.DoParseunreservedRule});
			m_nonterminals.Add("pct-encoded", new ParseMethod[]{this.DoParsepct_encodedRule});
			m_nonterminals.Add("sub-delims", new ParseMethod[]{this.DoParsesub_delimsRule});
			m_nonterminals.Add("alpha", new ParseMethod[]{this.DoParsealphaRule});
			m_nonterminals.Add("digit", new ParseMethod[]{this.DoParsedigitRule});
			m_nonterminals.Add("hexdig", new ParseMethod[]{this.DoParsehexdigRule});
			OnCtorEpilog();
		}
		
		public int Parse(string input)
		{
			return Parse(input, null);
		}
		
		// File is used for error reporting.
		public int Parse(string input, string file)
		{
			m_file = file;
			m_input = m_file;				// we need to ensure that m_file is used or we will (in some cases) get a compiler warning
			m_input = input + "\x0";	// add a sentinel so we can avoid range checks
			m_cache.Clear();
			m_consumed = 0;
			
			State state = new State(0, true);
			var results = new List<Result>();
			
			OnParseProlog();
			state = DoParse(state, results, "uri");
			
			m_consumed = state.Index;
			OnParseEpilog(state);
			
			return state.Index;
		}
		
		// Will be string.Empty if everything was consumed.
		public string Unconsumed
		{
			get {return m_input.Substring(m_consumed, m_input.Length - m_consumed - 1);}
		}
		
		#region Non-Terminal Parse Methods
		// uri := scheme ':' hier-part
		private State DoParseuriRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoSequence(_state, results,
			(s, r) => DoParse(s, r, "scheme"),
			(s, r) => DoParseLiteral(s, r, ":"),
			(s, r) => DoParse(s, r, "hier-part"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// scheme := alpha (alpha / digit / '+' / '-' / '.')*
		private State DoParseschemeRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoSequence(_state, results,
			(s, r) => DoParse(s, r, "alpha"),
			(s, r) => DoRepetition(s, r, 0, 2147483647,
				(s2, r2) => DoChoice(s2, r2,
					(s3, r3) => DoParse(s3, r3, "alpha"),
					(s3, r3) => DoParse(s3, r3, "digit"),
					(s3, r3) => DoParseLiteral(s3, r3, "+"),
					(s3, r3) => DoParseLiteral(s3, r3, "-"),
					(s3, r3) => DoParseLiteral(s3, r3, "."))));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// hier-part := '//' authority path-abempty
		private State DoParsehier_partRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoSequence(_state, results,
			(s, r) => DoParseLiteral(s, r, "//"),
			(s, r) => DoParse(s, r, "authority"),
			(s, r) => DoParse(s, r, "path-abempty"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// authority := (userinfo '@')? host (':' port)?
		private State DoParseauthorityRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoSequence(_state, results,
			(s, r) => DoRepetition(s, r, 0, 1,
				(s2, r2) => DoSequence(s2, r2,
					(s3, r3) => DoParse(s3, r3, "userinfo"),
					(s3, r3) => DoParseLiteral(s3, r3, "@"))),
			(s, r) => DoParse(s, r, "host"),
			(s, r) => DoRepetition(s, r, 0, 1,
				(s2, r2) => DoSequence(s2, r2,
					(s3, r3) => DoParseLiteral(s3, r3, ":"),
					(s3, r3) => DoParse(s3, r3, "port"))));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// userinfo := (unreserved / pct-encoded / sub-delims / ':')*
		private State DoParseuserinfoRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoRepetition(_state, results, 0, 2147483647,
			(s, r) => DoChoice(s, r,
				(s2, r2) => DoParse(s2, r2, "unreserved"),
				(s2, r2) => DoParse(s2, r2, "pct-encoded"),
				(s2, r2) => DoParse(s2, r2, "sub-delims"),
				(s2, r2) => DoParseLiteral(s2, r2, ":")));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// host := reg-name
		private State DoParsehostRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoParse(_state, results, "reg-name");
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// port := digit*
		private State DoParseportRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoRepetition(_state, results, 0, 2147483647,
			(s, r) => DoParse(s, r, "digit"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// reg-name := (unreserved / pct-encoded / sub-delims)*
		private State DoParsereg_nameRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoRepetition(_state, results, 0, 2147483647,
			(s, r) => DoChoice(s, r,
				(s2, r2) => DoParse(s2, r2, "unreserved"),
				(s2, r2) => DoParse(s2, r2, "pct-encoded"),
				(s2, r2) => DoParse(s2, r2, "sub-delims")));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// path-abempty := ('/' segment)*
		private State DoParsepath_abemptyRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoRepetition(_state, results, 0, 2147483647,
			(s, r) => DoSequence(s, r,
				(s2, r2) => DoParseLiteral(s2, r2, "/"),
				(s2, r2) => DoParse(s2, r2, "segment")));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// segment := pchar*
		private State DoParsesegmentRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoRepetition(_state, results, 0, 2147483647,
			(s, r) => DoParse(s, r, "pchar"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// pchar := unreserved / pct-encoded / sub-delims / ':' / '@'
		private State DoParsepcharRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoChoice(_state, results,
			(s, r) => DoParse(s, r, "unreserved"),
			(s, r) => DoParse(s, r, "pct-encoded"),
			(s, r) => DoParse(s, r, "sub-delims"),
			(s, r) => DoParseLiteral(s, r, ":"),
			(s, r) => DoParseLiteral(s, r, "@"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// unreserved := alpha / digit / '-' / '.' / '_' / '~'
		private State DoParseunreservedRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoChoice(_state, results,
			(s, r) => DoParse(s, r, "alpha"),
			(s, r) => DoParse(s, r, "digit"),
			(s, r) => DoParseLiteral(s, r, "-"),
			(s, r) => DoParseLiteral(s, r, "."),
			(s, r) => DoParseLiteral(s, r, "_"),
			(s, r) => DoParseLiteral(s, r, "~"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// pct-encoded := '%' hexdig hexdig
		private State DoParsepct_encodedRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoSequence(_state, results,
			(s, r) => DoParseLiteral(s, r, "%"),
			(s, r) => DoParse(s, r, "hexdig"),
			(s, r) => DoParse(s, r, "hexdig"));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// sub-delims := '!' / '$' / '&' / '\'' / '(' / ')' / '*' / '+' / ',' / ';' / '='
		private State DoParsesub_delimsRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoChoice(_state, results,
			(s, r) => DoParseLiteral(s, r, "!"),
			(s, r) => DoParseLiteral(s, r, "$"),
			(s, r) => DoParseLiteral(s, r, "&"),
			(s, r) => DoParseLiteral(s, r, "\'"),
			(s, r) => DoParseLiteral(s, r, "("),
			(s, r) => DoParseLiteral(s, r, ")"),
			(s, r) => DoParseLiteral(s, r, "*"),
			(s, r) => DoParseLiteral(s, r, "+"),
			(s, r) => DoParseLiteral(s, r, ","),
			(s, r) => DoParseLiteral(s, r, ";"),
			(s, r) => DoParseLiteral(s, r, "="));
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// alpha := [a-zA-Z]
		private State DoParsealphaRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoParseRange(_state, results, false, string.Empty, "azAZ", null, "[a-zA-Z]");
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// digit := [0-9]
		private State DoParsedigitRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoParseRange(_state, results, false, string.Empty, "09", null, "[0-9]");
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		
		// hexdig := [a-fA-F0-9]
		private State DoParsehexdigRule(State _state, List<Result> _outResults)
		{
			State _start = _state;
			var results = new List<Result>();
			
			_state = DoParseRange(_state, results, false, string.Empty, "afAF09", null, "[a-fA-F0-9]");
			
			if (_state.Parsed)
			{
				_outResults.Add(new Result(this, _start.Index, _state.Index - _start.Index, m_input));
			}
			
			return _state;
		}
		#endregion
		
		#region Private Helper Methods
		partial void OnCtorEpilog();
		partial void OnParseProlog();
		partial void OnParseEpilog(State state);
		
		public string DoEscapeAll(string s)
		{
			var builder = new System.Text.StringBuilder(s.Length);
			
			foreach (char ch in s)
			{
				if (ch == '\n')
					builder.Append("\\n");
				
				else if (ch == '\r')
					builder.Append("\\r");
				
				else if (ch == '\t')
					builder.Append("\\t");
				
				else if (ch < ' ')
					builder.AppendFormat("\\x{0:X2}", (int) ch);
				
				
				else
					builder.Append(ch);
			}
			
			return builder.ToString();
		}
		
		// This is normally only used for error handling so it doesn't need to be too
		// fast. If it somehow does become a bottleneck for some parsers they can
		// replace it with the custom-methods setting.
		private int DoGetLine(int index)
		{
			int line = 1;
			
			int i = 0;
			while (i <= index)
			{
				char ch = m_input[i++];
				
				if (ch == '\r' && m_input[i] == '\n')
				{
					++i;
					++line;
				}
				else if (ch == '\r')
				{
					++line;
				}
				else if (ch == '\n')
				{
					++line;
				}
			}
			
			return line;
		}
		
		private int DoGetCol(int index)
		{
			int start = index;
			
			while (index > 0 && m_input[index - 1] != '\n' && m_input[index - 1] != '\r')
			{
				--index;
			}
			
			return start - index + 1;
		}
		
		private State DoParseLiteral(State state, List<Result> results, string literal)
		{
			int j = state.Index;
			
			for (int i = 0; i < literal.Length; ++i)
			{
				if (m_input[j + i] != literal[i])
				{
					return new State(state.Index, false, new ErrorSet(state.Index, literal));
				}
			}
			
			int k = j + literal.Length;
			
			results.Add(new Result(this, j, literal.Length, m_input));
			state = new State(k, true, state.Errors);
			
			return state;
		}
		
		private State DoParse(State state, List<Result> results, string nonterminal)
		{
			State start = state;
			
			CacheValue cache;
			CacheKey key = new CacheKey(nonterminal, start.Index);
			if (!m_cache.TryGetValue(key, out cache))
			{
				ParseMethod[] methods = m_nonterminals[nonterminal];
				
				state = DoChoice(state, results, methods);
				
				cache = new CacheValue(state, state.Parsed);
				m_cache.Add(key, cache);
			}
			else
			{
				if (cache.HasResult)
					results.Add(new Result(this, start.Index, cache.State.Index - start.Index, m_input));
			}
			
			return cache.State;
		}
		
		private State DoChoice(State state, List<Result> results, params ParseMethod[] methods)
		{
			State start = state;
			int startResult = results.Count;
			
			foreach (ParseMethod method in methods)
			{
				State temp = method(state, results);
				if (temp.Parsed)
				{
					state = temp;
					break;
				}
				else
				{
					state = new State(start.Index, false, ErrorSet.Combine(state.Errors, temp.Errors));
					results.RemoveRange(startResult, results.Count - startResult);
				}
			}
			
			return state;
		}
		
		private State DoSequence(State state, List<Result> results, params ParseMethod[] methods)
		{
			State start = state;
			int startResult = results.Count;
			
			foreach (ParseMethod method in methods)
			{
				State temp = method(state, results);
				if (temp.Parsed)
				{
					state = temp;
				}
				else
				{
					state = new State(start.Index, false, ErrorSet.Combine(start.Errors, temp.Errors));
					results.RemoveRange(startResult, results.Count - startResult);
					break;
				}
			}
			
			return state;
		}
		
		private State DoRepetition(State state, List<Result> results, int min, int max, ParseMethod method)
		{
			State start = state;
			
			int count = 0;
			while (count <= max)
			{
				State temp = method(state, results);
				if (temp.Parsed && temp.Index > state.Index)
				{
					state = temp;
					++count;
				}
				else
				{
					state = new State(state.Index, true, ErrorSet.Combine(state.Errors, temp.Errors));
					break;
				}
			}
			
			if (count < min || count > max)
				state = new State(start.Index, false, ErrorSet.Combine(start.Errors, state.Errors));
			
			return state;
		}
		
		private State DoParseRange(State state, List<Result> results, bool inverted, string chars, string ranges, UnicodeCategory[] categories, string label)
		{
			char ch = m_input[state.Index];
			
			bool matched = chars.IndexOf(ch) >= 0;
			for (int i = 0; i < ranges.Length && !matched; i += 2)
			{
				matched = ranges[i] <= ch && ch <= ranges[i + 1];
			}
			for (int i = 0; categories != null && i < categories.Length && !matched; ++i)
			{
				matched = char.GetUnicodeCategory(ch) == categories[i];
			}
			
			if (inverted)
				matched = !matched;
			
			if (matched)
			{
				results.Add(new Result(this, state.Index, 1, m_input));
				return new State(state.Index + 1, true, state.Errors);
			}
			
			return new State(state.Index, false, new ErrorSet(state.Index, label));
		}
		#endregion
		
		#region Private Types
		private struct CacheKey : IEquatable<CacheKey>
		{
			public CacheKey(string rule, int index)
			{
				m_rule = rule;
				m_index = index;
			}
			
			public override bool Equals(object obj)
			{
				if (obj == null)
					return false;
				
				if (GetType() != obj.GetType())
					return false;
				
				CacheKey rhs = (CacheKey) obj;
				return this == rhs;
			}
			
			public bool Equals(CacheKey rhs)
			{
				return this == rhs;
			}
			
			public static bool operator==(CacheKey lhs, CacheKey rhs)
			{
				if (lhs.m_rule != rhs.m_rule)
					return false;
				
				if (lhs.m_index != rhs.m_index)
					return false;
				
				return true;
			}
			
			public static bool operator!=(CacheKey lhs, CacheKey rhs)
			{
				return !(lhs == rhs);
			}
			
			public override int GetHashCode()
			{
				int hash = 0;
				
				unchecked
				{
					hash += m_rule.GetHashCode();
					hash += m_index.GetHashCode();
				}
				
				return hash;
			}
			
			private string m_rule;
			private int m_index;
		}
		
		private struct CacheValue
		{
			public CacheValue(State state, bool hasResult)
			{
				State = state;
				HasResult = hasResult;
			}
			
			public State State {get; private set;}
			
			public bool HasResult {get; private set;}
		}
		
		private delegate State ParseMethod(State state, List<Result> results);
		
		// These are either an error that caused parsing to fail or the reason a
		// successful parse stopped.
		private struct ErrorSet
		{
			public ErrorSet(int index, string expected)
			{
				Index = index;
				Expected = new string[]{expected};
			}
			
			public ErrorSet(int index, string[] expected)
			{
				Index = index;
				Expected = expected;
			}
			
			// The location associated with the errors. For a failed parse this will be the
			// same as State.Index. For a successful parse it will be State.Index or later.
			public int Index {get; private set;}
			
			// This will be the name of something which was expected, but not found.
			public string[] Expected {get; private set;}
			
			public static ErrorSet Combine(ErrorSet lhs, ErrorSet rhs)
			{
				if (lhs.Index > rhs.Index)
				{
					return lhs;
				}
				else if (lhs.Index < rhs.Index)
				{
					return rhs;
				}
				else
				{
					var errors = new List<string>(lhs.Expected.Length + rhs.Expected.Length);
					errors.AddRange(lhs.Expected);
					foreach (string err in rhs.Expected)
					{
						if (errors.IndexOf(err) < 0)
							errors.Add(err);
					}
					return new ErrorSet(lhs.Index, errors.ToArray());
				}
			}
			
			public override string ToString()
			{
				if (Expected.Length > 0)
					return string.Format("Expected {0}", string.Join(" or ", Expected));
				else
					return "<none>";
			}
		}
		
		// The state of the parser.
		private struct State
		{
			public State(int index, bool parsed)
			{
				Index = index;
				Parsed = parsed;
				Errors = new ErrorSet(index, new string[0]);
			}
			
			public State(int index, bool parsed, ErrorSet errors)
			{
				Index = index;
				Parsed = parsed;
				Errors = errors;
			}
			
			// Index of the first unconsumed character.
			public int Index {get; private set;}
			
			// True if the expression associated with the state successfully parsed.
			public bool Parsed {get; private set;}
			
			// If Parsed is false then this will explain why. If Parsed is true it will
			// say why the parse stopped.
			public ErrorSet Errors {get; private set;}
		}
		
		// The result of parsing a literal or non-terminal.
		private struct Result
		{
			public Result(Test12 parser, int index, int length, string input)
			{
				m_parser = parser;
				m_index = index;
				m_length = length;
				m_input = input;
			}
			
			// The text which was parsed by the terminal or non-terminal.
			public string Text {get {return m_input.Substring(m_index, m_length);}}
			
			// The 1-based line number the (non)terminal started on.
			public int Line {get {return m_parser.DoGetLine(m_index);}}
			
			// The 1-based column number the (non)terminal started on.
			public int Col {get {return m_parser.DoGetCol(m_index);}}
			
			private Test12 m_parser;
			private int m_index;
			private int m_length;
			private string m_input;
		}
		
		#endregion
		
		#region Fields
		private string m_input;
		private string m_file;
		private Dictionary<string, ParseMethod[]> m_nonterminals = new Dictionary<string, ParseMethod[]>();
		private Dictionary<CacheKey, CacheValue> m_cache = new Dictionary<CacheKey, CacheValue>();
		private int m_consumed;
		#endregion
	}
}

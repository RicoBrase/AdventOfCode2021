using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2021.Day10;

public class ChunkParser
{
    private readonly string _input;
    
    private int _cursor;
    private ChunkInputCharacter? _currentInputChar;
    private bool _reconsume = false;
    private bool _isEol = false;
    
    private ChunkParserState _currentState = ChunkParserState.Begin;
    private ErrorScore _errorScore = ErrorScore.Valid;
    
    private readonly Stack<ChunkType> _openChunks = new();
    
    public ChunkParser(string input)
    {
        _input = input;
    }

    public (ErrorScore score, ChunkParserState finishState) RunAndGetScore()
    {
        // ConsumeNextInputCharacter();
        while (!_isEol)
        {
            RunParsingStep();
        }
        
        return (_errorScore, _currentState);
    }
    
    public List<ChunkInputCharacter> RunAndGetAutocompleteChars()
    {
        // ConsumeNextInputCharacter();
        while (!_isEol)
        {
            RunParsingStep();
        }

        var list = new List<ChunkInputCharacter>();

        while (_openChunks.Count > 0 && _currentState == ChunkParserState.IncompleteLine)
        {
            var inputChar = _openChunks.Pop() switch
            {
                ChunkType.Parentheses => ChunkInputCharacter.ParenthesesClose,
                ChunkType.Brackets => ChunkInputCharacter.BracketsClose,
                ChunkType.Braces => ChunkInputCharacter.BracesClose,
                ChunkType.Chevrons => ChunkInputCharacter.ChevronsClose,
                _ => throw new ArgumentOutOfRangeException()
            };
            list.Add(inputChar);
        }
        
        return list;
    }

    private void RunParsingStep()
    {
        switch (_currentState)
        {
            case ChunkParserState.Begin:
                ConsumeNextInputCharacter();
                switch (_currentInputChar)
                {
                    case ChunkInputCharacter.ParenthesesOpen:
                        SwitchToState(ChunkParserState.ParenthesesOpen);
                        break;
                    case ChunkInputCharacter.BracketsOpen:
                        SwitchToState(ChunkParserState.BracketsOpen);
                        break;
                    case ChunkInputCharacter.BracesOpen:
                        SwitchToState(ChunkParserState.BracesOpen);
                        break;
                    case ChunkInputCharacter.ChevronsOpen:
                        SwitchToState(ChunkParserState.ChevronsOpen);
                        break;
                    case ChunkInputCharacter.EOL:
                        SwitchToState(ChunkParserState.EndOfLine);
                        break;
                }
                break;
            
            // (
            case ChunkParserState.ParenthesesOpen:
                _openChunks.Push(ChunkType.Parentheses);
                SwitchToState(ChunkParserState.Chunk);
                break;
            
            // )
            case ChunkParserState.ParenthesesClose:
                if (_openChunks.Count > 0 && _openChunks.Peek() == ChunkType.Parentheses)
                {
                    _openChunks.Pop();
                    SwitchToState(ChunkParserState.Chunk);
                }
                else
                {
                    ReconsumeInState(ChunkParserState.CorruptedLine);
                }
                break;
            
            // [
            case ChunkParserState.BracketsOpen:
                _openChunks.Push(ChunkType.Brackets);
                SwitchToState(ChunkParserState.Chunk);
                break;
            
            // ]
            case ChunkParserState.BracketsClose:
                if (_openChunks.Count > 0 && _openChunks.Peek() == ChunkType.Brackets)
                {
                    _openChunks.Pop();
                    SwitchToState(ChunkParserState.Chunk);
                }
                else
                {
                    ReconsumeInState(ChunkParserState.CorruptedLine);
                }
                break;
            
            // {
            case ChunkParserState.BracesOpen:
                _openChunks.Push(ChunkType.Braces);
                SwitchToState(ChunkParserState.Chunk);
                break;
            
            // }
            case ChunkParserState.BracesClose:
                if (_openChunks.Count > 0 && _openChunks.Peek() == ChunkType.Braces)
                {
                    _openChunks.Pop();
                    SwitchToState(ChunkParserState.Chunk);
                }
                else
                {
                    ReconsumeInState(ChunkParserState.CorruptedLine);
                }
                break;
            
            // <
            case ChunkParserState.ChevronsOpen:
                _openChunks.Push(ChunkType.Chevrons);
                SwitchToState(ChunkParserState.Chunk);
                break;
            
            // >
            case ChunkParserState.ChevronsClose:
                if (_openChunks.Count > 0 && _openChunks.Peek() == ChunkType.Chevrons)
                {
                    _openChunks.Pop();
                    SwitchToState(ChunkParserState.Chunk);
                }
                else
                {
                    ReconsumeInState(ChunkParserState.CorruptedLine);
                }
                break;
            
            case ChunkParserState.Chunk:
                ConsumeNextInputCharacter();
                switch (_currentInputChar)
                {
                    case ChunkInputCharacter.ParenthesesOpen:
                        SwitchToState(ChunkParserState.ParenthesesOpen);
                        break;
                    
                    case ChunkInputCharacter.BracketsOpen:
                        SwitchToState(ChunkParserState.BracketsOpen);
                        break;
                    
                    case ChunkInputCharacter.BracesOpen:
                        SwitchToState(ChunkParserState.BracesOpen);
                        break;
                    
                    case ChunkInputCharacter.ChevronsOpen:
                        SwitchToState(ChunkParserState.ChevronsOpen);
                        break;
                    
                    case ChunkInputCharacter.ParenthesesClose:
                        SwitchToState(ChunkParserState.ParenthesesClose);
                        break;
                    
                    case ChunkInputCharacter.BracketsClose:
                        SwitchToState(ChunkParserState.BracketsClose);
                        break;
                    
                    case ChunkInputCharacter.BracesClose:
                        SwitchToState(ChunkParserState.BracesClose);
                        break;
                    
                    case ChunkInputCharacter.ChevronsClose:
                        SwitchToState(ChunkParserState.ChevronsClose);
                        break;
                    
                    case ChunkInputCharacter.EOL:
                        SwitchToState(_openChunks.Count > 0
                            ? ChunkParserState.IncompleteLine
                            : ChunkParserState.EndOfLine);
                        break;
                }
                break;
            
            case ChunkParserState.EndOfLine:
                _isEol = true;
                _errorScore = ErrorScore.Valid;
                break;
            
            case ChunkParserState.IncompleteLine:
                _isEol = true;
                _errorScore = ErrorScore.Valid;
                break;
            
            case ChunkParserState.CorruptedLine:
                ConsumeNextInputCharacter();
                _isEol = true;
                _errorScore = _currentInputChar switch
                {
                    ChunkInputCharacter.ParenthesesClose => ErrorScore.IllegalParenthesisClose,
                    ChunkInputCharacter.BracketsClose => ErrorScore.IllegalBracketsClose,
                    ChunkInputCharacter.BracesClose => ErrorScore.IllegalBracesClose,
                    ChunkInputCharacter.ChevronsClose => ErrorScore.IllegalChevronsClose,
                    _ => throw new ArgumentOutOfRangeException()
                };
                break;
        }
    }

    private void ConsumeNextInputCharacter()
    {
        if (_reconsume)
        {
            _reconsume = false;
            return;
        }

        if (_cursor < _input.Length)
        {
            _currentInputChar = _input[_cursor++] switch
            {
                '(' => ChunkInputCharacter.ParenthesesOpen,
                ')' => ChunkInputCharacter.ParenthesesClose,

                '[' => ChunkInputCharacter.BracketsOpen,
                ']' => ChunkInputCharacter.BracketsClose,

                '{' => ChunkInputCharacter.BracesOpen,
                '}' => ChunkInputCharacter.BracesClose,

                '<' => ChunkInputCharacter.ChevronsOpen,
                '>' => ChunkInputCharacter.ChevronsClose,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        else
        {
            _currentInputChar = ChunkInputCharacter.EOL;
        }
    }

    private void ReconsumeInState(ChunkParserState state)
    {
        _reconsume = true;
        SwitchToState(state);
    }

    private void SwitchToState(ChunkParserState newState)
    {
        _currentState = newState;
        RunParsingStep();
    }
}
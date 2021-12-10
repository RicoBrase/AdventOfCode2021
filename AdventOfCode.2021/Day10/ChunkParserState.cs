namespace AdventOfCode._2021.Day10;

public enum ChunkParserState
{
    Begin,
    
    ParenthesesOpen,
    ParenthesesClose,
    BracketsOpen,
    BracketsClose,
    BracesOpen,
    BracesClose,
    ChevronsOpen,
    ChevronsClose,
    
    Chunk,
    
    EndOfLine,
    IncompleteLine,
    CorruptedLine
}
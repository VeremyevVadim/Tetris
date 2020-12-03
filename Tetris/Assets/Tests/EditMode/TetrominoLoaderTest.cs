using NUnit.Framework;

public class TetrominoLoaderTest
{
    
    [Test]
    public void TetrominoLoaderTestLoadTetrominos()
    {
        var tetrominoLoader = new TetrominoLoader();

        var tetrominos = tetrominoLoader.LoadTetrominos();

        Assert.AreEqual(true, tetrominos.Length > 0);
    }
}


CREATE TRIGGER AddScoreInComment
ON Comments
AFTER INSERT
AS
BEGIN
    DECLARE @Id int
    DECLARE @Score int
    -- Inserted tablosunu ge�ici bir tabloya y�nlendirin
    DECLARE @Inserted TABLE (BlogId INT, BlogScore INT)
    INSERT INTO @Inserted (BlogId, BlogScore)
    SELECT BlogId, BlogScore FROM inserted

    -- Ge�ici tablodan de�erleri al�n
    SELECT @Id = BlogId, @Score = BlogScore FROM @Inserted

    -- BlogRaytings tablosunu g�ncelleyin
    UPDATE BlogRaytings 
    SET BlogTotalScore = BlogTotalScore + @Score, 
        BlogRaytingCount = BlogRaytingCount + 1
    WHERE BlogId = @Id
END

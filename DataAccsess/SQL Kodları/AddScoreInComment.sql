CREATE TRIGGER AddScoreInComment
ON Comments
AFTER INSERT
AS
BEGIN
    DECLARE @Id int
    DECLARE @Score int
    -- Inserted tablosunu geçici bir tabloya yönlendirin
    DECLARE @Inserted TABLE (BlogId INT, BlogScore INT)
    INSERT INTO @Inserted (BlogId, BlogScore)
    SELECT BlogId, BlogScore FROM inserted

    -- Geçici tablodan deðerleri alýn
    SELECT @Id = BlogId, @Score = BlogScore FROM @Inserted

    -- BlogRaytings tablosunu güncelleyin
    UPDATE BlogRaytings 
    SET BlogTotalScore = BlogTotalScore + @Score, 
        BlogRaytingCount = BlogRaytingCount + 1
    WHERE BlogId = @Id
END

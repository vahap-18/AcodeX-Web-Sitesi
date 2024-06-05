CREATE TRIGGER AddScoreInComment
ON Comments
AFTER INSERT
AS
BEGIN
    DECLARE @Id int
    DECLARE @Score int
    -- Inserted tablosunu kullanarak BlogId ve BlogScore deðerlerini alýn
    SELECT @Id = BlogId, @Score = BlogScore FROM inserted

    -- BlogRaytings tablosunu güncelleyin
    UPDATE BlogRaytings 
    SET BlogTotalScore = BlogTotalScore + @Score, 
        BlogRaytingCount = BlogRaytingCount + 1
    WHERE BlogId = @Id
END

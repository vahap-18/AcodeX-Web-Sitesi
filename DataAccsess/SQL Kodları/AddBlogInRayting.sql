CREATE TRIGGER AddBlogInRayting
ON Blogs
AFTER INSERT
AS
BEGIN
    Declare @Id int
    -- Inserted tablosunu geçici bir tabloya yönlendirin
    DECLARE @Inserted TABLE (BlogId INT)
    INSERT INTO @Inserted (BlogId)
    SELECT BlogId FROM inserted

    -- Geçici tablodan deðeri alýn
    SELECT @Id = BlogId FROM @Inserted

    -- BlogRaytings tablosuna veri ekleyin
    INSERT INTO BlogRaytings (BlogId, BlogTotalScore, BlogRaytingCount)
    VALUES (@Id, 0, 0)
END

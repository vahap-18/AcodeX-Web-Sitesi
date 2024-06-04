CREATE TRIGGER AddBlogInRayting
ON Blogs
AFTER INSERT
AS
BEGIN
    Declare @Id int
    -- Inserted tablosunu ge�ici bir tabloya y�nlendirin
    DECLARE @Inserted TABLE (BlogId INT)
    INSERT INTO @Inserted (BlogId)
    SELECT BlogId FROM inserted

    -- Ge�ici tablodan de�eri al�n
    SELECT @Id = BlogId FROM @Inserted

    -- BlogRaytings tablosuna veri ekleyin
    INSERT INTO BlogRaytings (BlogId, BlogTotalScore, BlogRaytingCount)
    VALUES (@Id, 0, 0)
END

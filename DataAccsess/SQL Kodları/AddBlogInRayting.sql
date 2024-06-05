CREATE TRIGGER AddBlogInRayting
ON Blogs
AFTER INSERT
AS
BEGIN
    DECLARE @Id int

    -- Inserted tablosunu kullanarak BlogId de�erini al�n
    SELECT @Id = BlogId FROM inserted

    -- BlogRaytings tablosuna veri ekleyin
    INSERT INTO BlogRaytings (BlogId, BlogTotalScore, BlogRaytingCount)
    VALUES (@Id, 0, 0)
END

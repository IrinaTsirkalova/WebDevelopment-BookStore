USE [LibraryDB]
GO

ALTER TABLE [dbo].[BorrowedBooks] DROP CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Books_BookId]
GO

ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Book_Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BorrowedBooks] CHECK CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Books_BookId]
GO



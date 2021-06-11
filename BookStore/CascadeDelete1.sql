USE [LibraryDB]
GO

ALTER TABLE [dbo].[BorrowedBooks] DROP CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Users_UserId]
GO

ALTER TABLE [dbo].[BorrowedBooks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([User_Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BorrowedBooks] CHECK CONSTRAINT [FK_dbo.BorrowedBooks_dbo.Users_UserId]
GO



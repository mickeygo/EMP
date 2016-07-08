
-- Product
CREATE TABLE Product (
	ProductId				uniqueidentifier	not null,
	Name					varchar(30)			not null,
	Model					varchar(100)		not null,
	IsDeleted				bit					not null,
	CreatorUserId			uniqueidentifier	not null,
	CreationTime			datetime			not null,
	LastModifierUserId		uniqueidentifier	null,
	LastModificationTime	datetime			null,
	DeleterUserId			uniqueidentifier	null,
	DeletionTime			datetime			null,
	CONSTRAINT [PK_Product] PRIMARY KEY (ProductId)
);

-- Order
CREATE TABLE PO (
	OrderId					uniqueidentifier	not null,
	OrderNo					varchar(30)			not null,
	IsDeleted				bit					not null,
	CreatorUserId			uniqueidentifier	not null,
	CreationTime			datetime			not null,
	LastModifierUserId		uniqueidentifier	null,
	LastModificationTime	datetime			null,
	DeleterUserId			uniqueidentifier	null,
	DeletionTime			datetime			null,
	CONSTRAINT [PK_PO] PRIMARY KEY (OrderId)
);

-- OrderLine
CREATE TABLE OrderLine (
	OrderLineId				uniqueidentifier	not null,
	OrderId					uniqueidentifier	not null,
	ProductId				uniqueidentifier	not null,
	Qty						int					not null,
	CreatorUserId			uniqueidentifier	not null,
	CreationTime			datetime			not null,
	LastModifierUserId		uniqueidentifier	null,
	LastModificationTime	datetime			null,
	CONSTRAINT [PK_OrderLine] PRIMARY KEY (OrderLineId)
);

ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo]. [PO] ([OrderId]);

ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo]. [Product] ([ProductId]);



--- Table: EventSource

CREATE TABLE EventSource (
	EventId					uniqueidentifier	NOT NULL,
	EventTypeName			varchar(256)		NOT NULL,
	AggregateRootTypeName	varchar(256)		NOT NULL,
	AggregateRootId			uniqueidentifier	NOT NULL,
	[Source]				nvarchar(max)		NOT	NULL,
	[Version]				int					NOT	NULL,
	[TimeStamp]				datetimeoffset(4)	NOT	NULL,
	CONSTRAINT [PK_EventSource] PRIMARY KEY (EventId)
);
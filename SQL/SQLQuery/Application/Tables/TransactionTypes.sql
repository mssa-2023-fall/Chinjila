CREATE TABLE [Application].[TransactionTypes] (
    [TransactionTypeID]   INT                                         NOT NULL,
    [TransactionTypeName] NVARCHAR (50)                               NOT NULL,
    [LastEditedBy]        INT                                         NOT NULL,
    [ValidFrom]           DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]             DATETIME2 (7) GENERATED ALWAYS AS ROW END   NOT NULL,
    PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[Application].[TransactionTypes_Archive], DATA_CONSISTENCY_CHECK=ON));
GO

EXECUTE sp_addextendedproperty @name = N'Description', @value = 'Numeric ID used for reference to a transaction type within the database', @level0type = N'SCHEMA', @level0name = N'Application', @level1type = N'TABLE', @level1name = N'TransactionTypes', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';
GO

EXECUTE sp_addextendedproperty @name = N'Description', @value = 'Full name of the transaction type', @level0type = N'SCHEMA', @level0name = N'Application', @level1type = N'TABLE', @level1name = N'TransactionTypes', @level2type = N'COLUMN', @level2name = N'TransactionTypeName';
GO

ALTER TABLE [Application].[TransactionTypes]
    ADD CONSTRAINT [FK_Application_TransactionTypes_Application_People] FOREIGN KEY ([LastEditedBy]) REFERENCES [Application].[People] ([PersonID]);
GO

ALTER TABLE [Application].[TransactionTypes]
    ADD CONSTRAINT [PK_Application_TransactionTypes] PRIMARY KEY CLUSTERED ([TransactionTypeID] ASC);
GO

ALTER TABLE [Application].[TransactionTypes]
    ADD CONSTRAINT [UQ_Application_TransactionTypes_TransactionTypeName] UNIQUE NONCLUSTERED ([TransactionTypeName] ASC);
GO

ALTER TABLE [Application].[TransactionTypes]
    ADD CONSTRAINT [DF_Application_TransactionTypes_TransactionTypeID] DEFAULT (NEXT VALUE FOR [Sequences].[TransactionTypeID]) FOR [TransactionTypeID];
GO

EXECUTE sp_addextendedproperty @name = N'Description', @value = N'Types of customer, supplier, or stock transactions (ie: invoice, credit note, etc.)', @level0type = N'SCHEMA', @level0name = N'Application', @level1type = N'TABLE', @level1name = N'TransactionTypes';
GO


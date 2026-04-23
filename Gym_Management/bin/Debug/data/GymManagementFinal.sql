IF DB_ID(N'GymManagementFinal') IS NOT NULL
BEGIN
    ALTER DATABASE GymManagementFinal SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GymManagementFinal;
END
GO

CREATE DATABASE GymManagementFinal;
GO
USE GymManagementFinal;
GO

SET NOCOUNT ON;
GO

/* =========================================================
   1. CORE TABLES
========================================================= */
CREATE TABLE dbo.SystemConfig (
    Id INT NOT NULL PRIMARY KEY,
    BaseSalaryPerShift DECIMAL(10,2) NOT NULL CHECK (BaseSalaryPerShift >= 0)
);
GO

CREATE TABLE dbo.StaffLevels (
    LevelId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL UNIQUE,
    MinExperience INT NOT NULL CHECK (MinExperience >= 0),
    MaxExperience INT NOT NULL,
    SalaryPercentIncrease INT NOT NULL CHECK (SalaryPercentIncrease >= 0),
    CONSTRAINT CHK_StaffLevels_ExperienceRange CHECK (MaxExperience >= MinExperience)
);
GO

CREATE TABLE dbo.Users (
    UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL UNIQUE,
    Email NVARCHAR(100) NULL,
    Avatar NVARCHAR(255) NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Staff')),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Users_Status DEFAULT 'Active' CHECK (Status IN ('Active','Inactive')),
    Experience INT NOT NULL CONSTRAINT DF_Users_Experience DEFAULT 0 CHECK (Experience >= 0),
    LevelId INT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT CHK_Users_Phone CHECK (Phone IS NULL OR LEN(Phone) >= 9),
    CONSTRAINT CHK_Users_Email CHECK (Email IS NULL OR Email LIKE '%@%'),
    CONSTRAINT FK_Users_StaffLevels FOREIGN KEY (LevelId) REFERENCES dbo.StaffLevels(LevelId)
);
GO

CREATE TABLE dbo.PendingUsers (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_PendingUsers_Status DEFAULT 'Pending' CHECK (Status IN ('Pending','Approved','Rejected')),
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_PendingUsers_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT CHK_PendingUsers_Phone CHECK (Phone IS NULL OR LEN(Phone) >= 9),
    CONSTRAINT CHK_PendingUsers_Email CHECK (Email IS NULL OR Email LIKE '%@%')
);
GO

CREATE TABLE dbo.WorkShifts (
    ShiftId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    MaxStaff INT NOT NULL CONSTRAINT DF_WorkShifts_MaxStaff DEFAULT 3 CHECK (MaxStaff > 0),
    CONSTRAINT CHK_WorkShifts_Time CHECK (EndTime > StartTime)
);
GO

CREATE TABLE dbo.UserShifts (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    ShiftId INT NOT NULL,
    WorkDate DATE NOT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_UserShifts_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT UQ_UserShift UNIQUE (UserId, ShiftId, WorkDate),
    CONSTRAINT FK_UserShifts_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId),
    CONSTRAINT FK_UserShifts_WorkShifts FOREIGN KEY (ShiftId) REFERENCES dbo.WorkShifts(ShiftId)
);
GO

CREATE TABLE dbo.Attendances (
    AttendanceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    ShiftId INT NULL,
    WorkDate DATE NOT NULL,
    CheckIn DATETIME NULL,
    CheckOut DATETIME NULL,
    CONSTRAINT FK_Attendances_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId),
    CONSTRAINT FK_Attendances_WorkShifts FOREIGN KEY (ShiftId) REFERENCES dbo.WorkShifts(ShiftId)
);
GO

CREATE TABLE dbo.Customers (
    CustomerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL UNIQUE,
    Address NVARCHAR(255) NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Customers_CreatedAt DEFAULT GETDATE(),
    CONSTRAINT CHK_Customers_Phone CHECK (Phone IS NULL OR LEN(Phone) >= 9)
);
GO

CREATE TABLE dbo.MemberProfiles (
    CustomerId INT NOT NULL PRIMARY KEY,
    Avatar NVARCHAR(255) NULL,
    IdentityNumber NVARCHAR(50) NULL,
    CardCode NVARCHAR(50) NULL UNIQUE,
    JoinDate DATE NOT NULL CONSTRAINT DF_MemberProfiles_JoinDate DEFAULT CAST(GETDATE() AS DATE),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_MemberProfiles_Status DEFAULT 'Active' CHECK (Status IN ('Active','Inactive','Blocked')),
    CONSTRAINT FK_MemberProfiles_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId)
);
GO

CREATE TABLE dbo.TrainerLevels (
    LevelId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL UNIQUE,
    MinExperience INT NOT NULL CHECK (MinExperience >= 0),
    MaxExperience INT NOT NULL,
    PricePercentIncrease INT NOT NULL CHECK (PricePercentIncrease >= 0),
    CONSTRAINT CHK_TrainerLevels_ExperienceRange CHECK (MaxExperience >= MinExperience)
);
GO

CREATE TABLE dbo.Trainers (
    TrainerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Experience INT NOT NULL CONSTRAINT DF_Trainers_Experience DEFAULT 0 CHECK (Experience >= 0),
    SalaryPercent INT NOT NULL CONSTRAINT DF_Trainers_SalaryPercent DEFAULT 0 CHECK (SalaryPercent BETWEEN 0 AND 100),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Trainers_Status DEFAULT 'Active' CHECK (Status IN ('Active','Inactive')),
    Avatar NVARCHAR(255) NULL,
    Specialty NVARCHAR(100) NULL,
    LevelId INT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Trainers_CreatedAt DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    CONSTRAINT CHK_Trainers_Email CHECK (Email IS NULL OR Email LIKE '%@%'),
    CONSTRAINT FK_Trainers_TrainerLevels FOREIGN KEY (LevelId) REFERENCES dbo.TrainerLevels(LevelId)
);
GO

CREATE TABLE dbo.Packages (
    PackageId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    DurationValue INT NOT NULL CHECK (DurationValue > 0),
    DurationType NVARCHAR(20) NOT NULL CHECK (DurationType IN ('Day','Month','Year')),
    Description NVARCHAR(255) NULL
);
GO

CREATE TABLE dbo.Memberships (
    MembershipId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NOT NULL,
    PackageId INT NOT NULL,
    TrainerId INT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Memberships_Status DEFAULT 'Pending' CHECK (Status IN ('Pending','Active','Expired','Cancelled')),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Memberships_CreatedAt DEFAULT GETDATE(),
    CreatedByStaffId INT NULL,
    CONSTRAINT CHK_Memberships_Date CHECK (EndDate > StartDate),
    CONSTRAINT FK_Memberships_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
    CONSTRAINT FK_Memberships_Packages FOREIGN KEY (PackageId) REFERENCES dbo.Packages(PackageId),
    CONSTRAINT FK_Memberships_Trainers FOREIGN KEY (TrainerId) REFERENCES dbo.Trainers(TrainerId),
    CONSTRAINT FK_Memberships_Users FOREIGN KEY (CreatedByStaffId) REFERENCES dbo.Users(UserId)
);
GO

CREATE TABLE dbo.MembershipPayments (
    MembershipPaymentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MembershipId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
    PaymentDate DATETIME NOT NULL CONSTRAINT DF_MembershipPayments_PaymentDate DEFAULT GETDATE(),
    Method NVARCHAR(20) NOT NULL CHECK (Method IN ('Cash','Online')),
    CashReceived DECIMAL(10,2) NULL,
    ChangeAmount DECIMAL(10,2) NULL,
    Note NVARCHAR(255) NULL,
    ReceivedByStaffId INT NULL,
    CONSTRAINT FK_MembershipPayments_Memberships FOREIGN KEY (MembershipId) REFERENCES dbo.Memberships(MembershipId),
    CONSTRAINT FK_MembershipPayments_Users FOREIGN KEY (ReceivedByStaffId) REFERENCES dbo.Users(UserId)
);
GO

CREATE TABLE dbo.Checkins (
    CheckinId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NOT NULL,
    MembershipId INT NOT NULL,
    CheckinTime DATETIME NOT NULL CONSTRAINT DF_Checkins_CheckinTime DEFAULT GETDATE(),
    CONSTRAINT FK_Checkins_MemberProfiles FOREIGN KEY (CustomerId) REFERENCES dbo.MemberProfiles(CustomerId),
    CONSTRAINT FK_Checkins_Memberships FOREIGN KEY (MembershipId) REFERENCES dbo.Memberships(MembershipId)
);
GO

CREATE TABLE dbo.Brands (
    BrandId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE dbo.Units (
    UnitId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE dbo.Products (
    ProductId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    BrandId INT NULL,
    UnitId INT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    Quantity INT NOT NULL CONSTRAINT DF_Products_Quantity DEFAULT 0 CHECK (Quantity >= 0),
    Barcode NVARCHAR(50) NULL UNIQUE,
    Image NVARCHAR(255) NULL,
    Description NVARCHAR(255) NULL,
    CONSTRAINT FK_Products_Brands FOREIGN KEY (BrandId) REFERENCES dbo.Brands(BrandId),
    CONSTRAINT FK_Products_Units FOREIGN KEY (UnitId) REFERENCES dbo.Units(UnitId)
);
GO

CREATE TABLE dbo.Suppliers (
    SupplierId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(255) NULL,
    TaxCode NVARCHAR(50) NULL,
    Note NVARCHAR(255) NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Suppliers_Status DEFAULT 'Active' CHECK (Status IN ('Active','Inactive')),
    CONSTRAINT CHK_Suppliers_Email CHECK (Email IS NULL OR Email LIKE '%@%')
);
GO

CREATE TABLE dbo.SupplierContacts (
    ContactId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SupplierId INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    Position NVARCHAR(100) NULL,
    IsPrimary BIT NOT NULL CONSTRAINT DF_SupplierContacts_IsPrimary DEFAULT 0,
    Note NVARCHAR(255) NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_SupplierContacts_Status DEFAULT 'Active' CHECK (Status IN ('Active','Inactive')),
    CONSTRAINT FK_SupplierContacts_Suppliers FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId),
    CONSTRAINT CHK_SupplierContacts_Email CHECK (Email IS NULL OR Email LIKE '%@%')
);
GO

CREATE TABLE dbo.ImportReceipts (
    ImportId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ImportCode NVARCHAR(30) NULL UNIQUE,
    [Date] DATETIME NOT NULL CONSTRAINT DF_ImportReceipts_Date DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL CONSTRAINT DF_ImportReceipts_Total DEFAULT 0 CHECK (Total >= 0),
    SupplierId INT NULL,
    SupplierContactId INT NULL,
    ContactId INT NULL,
    PaidAmount DECIMAL(10,2) NOT NULL CONSTRAINT DF_ImportReceipts_PaidAmount DEFAULT 0 CHECK (PaidAmount >= 0),
    DebtAmount DECIMAL(10,2) NOT NULL CONSTRAINT DF_ImportReceipts_DebtAmount DEFAULT 0 CHECK (DebtAmount >= 0),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_ImportReceipts_Status DEFAULT 'Draft' CHECK (Status IN ('Draft','Completed','PartialPaid','Unpaid','Cancelled')),
    Note NVARCHAR(255) NULL,
    CreatedByAdminId INT NULL,
    CONSTRAINT FK_ImportReceipts_Suppliers FOREIGN KEY (SupplierId) REFERENCES dbo.Suppliers(SupplierId),
    CONSTRAINT FK_ImportReceipts_SupplierContacts FOREIGN KEY (SupplierContactId) REFERENCES dbo.SupplierContacts(ContactId),
    CONSTRAINT FK_ImportReceipts_Users FOREIGN KEY (CreatedByAdminId) REFERENCES dbo.Users(UserId)
);
GO

CREATE TABLE dbo.ImportDetails (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ImportId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    CONSTRAINT FK_ImportDetails_ImportReceipts FOREIGN KEY (ImportId) REFERENCES dbo.ImportReceipts(ImportId),
    CONSTRAINT FK_ImportDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
);
GO

CREATE TABLE dbo.SalesInvoices (
    SalesInvoiceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CustomerId INT NULL,
    InvoiceDate DATETIME NOT NULL CONSTRAINT DF_SalesInvoices_InvoiceDate DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL CONSTRAINT DF_SalesInvoices_Total DEFAULT 0 CHECK (Total >= 0),
    Note NVARCHAR(255) NULL,
    CreatedByStaffId INT NULL,
    CONSTRAINT FK_SalesInvoices_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
    CONSTRAINT FK_SalesInvoices_Users FOREIGN KEY (CreatedByStaffId) REFERENCES dbo.Users(UserId)
);
GO

CREATE TABLE dbo.SalesInvoiceDetails (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SalesInvoiceId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    CONSTRAINT FK_SalesInvoiceDetails_SalesInvoices FOREIGN KEY (SalesInvoiceId) REFERENCES dbo.SalesInvoices(SalesInvoiceId),
    CONSTRAINT FK_SalesInvoiceDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
);
GO

CREATE TABLE dbo.SalesPayments (
    SalesPaymentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SalesInvoiceId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
    PaymentDate DATETIME NOT NULL CONSTRAINT DF_SalesPayments_PaymentDate DEFAULT GETDATE(),
    Method NVARCHAR(20) NOT NULL CHECK (Method IN ('Cash','Online')),
    CashReceived DECIMAL(10,2) NULL,
    ChangeAmount DECIMAL(10,2) NULL,
    ReceivedByStaffId INT NULL,
    CONSTRAINT FK_SalesPayments_SalesInvoices FOREIGN KEY (SalesInvoiceId) REFERENCES dbo.SalesInvoices(SalesInvoiceId),
    CONSTRAINT FK_SalesPayments_Users FOREIGN KEY (ReceivedByStaffId) REFERENCES dbo.Users(UserId)
);
GO

CREATE TABLE dbo.MembershipLogs (
    LogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MembershipId INT NOT NULL,
    Action NVARCHAR(50) NOT NULL,
    ChangeDate DATETIME NOT NULL CONSTRAINT DF_MembershipLogs_ChangeDate DEFAULT GETDATE(),
    OldEndDate DATE NULL,
    NewEndDate DATE NULL,
    Note NVARCHAR(255) NULL,
    CONSTRAINT FK_MembershipLogs_Memberships FOREIGN KEY (MembershipId) REFERENCES dbo.Memberships(MembershipId)
);
GO

CREATE TABLE dbo.PTSchedules (
    ScheduleId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MembershipId INT NOT NULL,
    CustomerId INT NOT NULL,
    TrainerId INT NOT NULL,
    ScheduledDate DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_PTSchedules_Status DEFAULT 'Scheduled' CHECK (Status IN ('Scheduled','Done','Cancelled')),
    Note NVARCHAR(255) NULL,
    CreatedByStaffId INT NULL,
    UpdatedAt DATETIME NULL,
    CONSTRAINT CHK_PTSchedules_Time CHECK (EndTime > StartTime),
    CONSTRAINT FK_PTSchedules_Memberships FOREIGN KEY (MembershipId) REFERENCES dbo.Memberships(MembershipId),
    CONSTRAINT FK_PTSchedules_Customers FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(CustomerId),
    CONSTRAINT FK_PTSchedules_Trainers FOREIGN KEY (TrainerId) REFERENCES dbo.Trainers(TrainerId),
    CONSTRAINT FK_PTSchedules_Users FOREIGN KEY (CreatedByStaffId) REFERENCES dbo.Users(UserId)
);
GO

/* =========================================================
   2. INDEXES
========================================================= */
CREATE INDEX IX_Customers_Phone ON dbo.Customers(Phone);
CREATE INDEX IX_Products_Name ON dbo.Products(Name);
CREATE INDEX IX_Memberships_Customer ON dbo.Memberships(CustomerId);
CREATE INDEX IX_Memberships_Trainer ON dbo.Memberships(TrainerId);
CREATE INDEX IX_MembershipPayments_Date ON dbo.MembershipPayments(PaymentDate);
CREATE INDEX IX_SalesPayments_Date ON dbo.SalesPayments(PaymentDate);
CREATE INDEX IX_UserShifts_Date ON dbo.UserShifts(WorkDate);
CREATE INDEX IX_Attendances_UserDate ON dbo.Attendances(UserId, WorkDate);
CREATE INDEX IX_ImportReceipts_Date ON dbo.ImportReceipts([Date]);
CREATE INDEX IX_ImportReceipts_Supplier ON dbo.ImportReceipts(SupplierId);
CREATE INDEX IX_SupplierContacts_Supplier ON dbo.SupplierContacts(SupplierId);
CREATE INDEX IX_PTSchedules_Date ON dbo.PTSchedules(ScheduledDate);
CREATE INDEX IX_PTSchedules_TrainerDate ON dbo.PTSchedules(TrainerId, ScheduledDate);
CREATE INDEX IX_PTSchedules_CustomerDate ON dbo.PTSchedules(CustomerId, ScheduledDate);
GO

/* =========================================================
   3. TYPE + TRIGGERS
========================================================= */
CREATE TYPE dbo.SalesCheckoutItemType AS TABLE
(
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

CREATE TRIGGER dbo.trg_Import_AddStock
ON dbo.ImportDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE p
    SET p.Quantity = p.Quantity + i.Quantity
    FROM dbo.Products p
    JOIN inserted i ON p.ProductId = i.ProductId;
END;
GO

CREATE TRIGGER dbo.trg_LogMembership
ON dbo.Memberships
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.MembershipLogs (MembershipId, Action, OldEndDate, NewEndDate, Note)
    SELECT
        i.MembershipId,
        CASE WHEN d.MembershipId IS NULL THEN N'CREATED' ELSE N'UPDATED' END,
        d.EndDate,
        i.EndDate,
        N'Cập nhật bởi hệ thống'
    FROM inserted i
    LEFT JOIN deleted d ON d.MembershipId = i.MembershipId;
END;
GO

/* =========================================================
   4. FUNCTIONS + STORED PROCEDURES
========================================================= */
CREATE OR ALTER FUNCTION dbo.fn_GenerateNextCardCode()
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @Next INT;

    SELECT @Next = ISNULL(MAX(TRY_CAST(SUBSTRING(CardCode, 5, LEN(CardCode)) AS INT)), 0) + 1
    FROM dbo.MemberProfiles
    WHERE CardCode LIKE 'CARD%';

    RETURN N'CARD' + RIGHT('0000' + CAST(@Next AS VARCHAR(10)), 4);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GenerateNextCardCode
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Next INT;
    BEGIN TRAN;

    SELECT @Next = ISNULL(MAX(TRY_CAST(SUBSTRING(CardCode, 5, LEN(CardCode)) AS INT)), 0) + 1
    FROM dbo.MemberProfiles WITH (UPDLOCK, HOLDLOCK)
    WHERE CardCode LIKE 'CARD%';

    COMMIT;
    SELECT N'CARD' + RIGHT('0000' + CAST(@Next AS VARCHAR(10)), 4) AS CardCode;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddBrand
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF LTRIM(RTRIM(ISNULL(@Name, N''))) = N''
    BEGIN
        RAISERROR(N'Tên hãng không được để trống.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Brands WHERE Name = @Name)
    BEGIN
        SELECT TOP 1 BrandId, Name FROM dbo.Brands WHERE Name = @Name;
        RETURN;
    END

    INSERT INTO dbo.Brands(Name) VALUES (@Name);
    SELECT BrandId, Name FROM dbo.Brands WHERE BrandId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddUnit
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF LTRIM(RTRIM(ISNULL(@Name, N''))) = N''
    BEGIN
        RAISERROR(N'Tên đơn vị không được để trống.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Units WHERE Name = @Name)
    BEGIN
        SELECT TOP 1 UnitId, Name FROM dbo.Units WHERE Name = @Name;
        RETURN;
    END

    INSERT INTO dbo.Units(Name) VALUES (@Name);
    SELECT UnitId, Name FROM dbo.Units WHERE UnitId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddSupplier
    @Name NVARCHAR(150),
    @Phone NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Address NVARCHAR(255) = NULL,
    @TaxCode NVARCHAR(50) = NULL,
    @Note NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF LTRIM(RTRIM(ISNULL(@Name, N''))) = N''
    BEGIN
        RAISERROR(N'Tên nhà cung cấp không được để trống.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Suppliers WHERE Name = @Name)
    BEGIN
        SELECT TOP 1 * FROM dbo.Suppliers WHERE Name = @Name;
        RETURN;
    END

    INSERT INTO dbo.Suppliers(Name, Phone, Email, Address, TaxCode, Note, Status)
    VALUES (@Name, @Phone, @Email, @Address, @TaxCode, @Note, 'Active');

    SELECT * FROM dbo.Suppliers WHERE SupplierId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddSupplierContact
    @SupplierId INT,
    @FullName NVARCHAR(100),
    @Phone NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Position NVARCHAR(100) = NULL,
    @IsPrimary BIT = 0,
    @Note NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Suppliers WHERE SupplierId = @SupplierId)
    BEGIN
        RAISERROR(N'Nhà cung cấp không tồn tại.', 16, 1);
        RETURN;
    END

    IF LTRIM(RTRIM(ISNULL(@FullName, N''))) = N''
    BEGIN
        RAISERROR(N'Tên người liên hệ không được để trống.', 16, 1);
        RETURN;
    END

    IF @IsPrimary = 1
    BEGIN
        UPDATE dbo.SupplierContacts
        SET IsPrimary = 0
        WHERE SupplierId = @SupplierId;
    END

    INSERT INTO dbo.SupplierContacts(SupplierId, FullName, Phone, Email, Position, IsPrimary, Note, Status)
    VALUES (@SupplierId, @FullName, @Phone, @Email, @Position, @IsPrimary, @Note, 'Active');

    SELECT * FROM dbo.SupplierContacts WHERE ContactId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddProduct
    @Name NVARCHAR(100),
    @BrandId INT = NULL,
    @UnitId INT = NULL,
    @Price DECIMAL(10,2),
    @Barcode NVARCHAR(50) = NULL,
    @Image NVARCHAR(255) = NULL,
    @Description NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF LTRIM(RTRIM(ISNULL(@Name, N''))) = N''
    BEGIN
        RAISERROR(N'Tên sản phẩm không được để trống.', 16, 1);
        RETURN;
    END

    IF @Price < 0
    BEGIN
        RAISERROR(N'Giá bán không hợp lệ.', 16, 1);
        RETURN;
    END

    IF @BrandId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Brands WHERE BrandId = @BrandId)
    BEGIN
        RAISERROR(N'Hãng không tồn tại.', 16, 1);
        RETURN;
    END

    IF @UnitId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Units WHERE UnitId = @UnitId)
    BEGIN
        RAISERROR(N'Đơn vị không tồn tại.', 16, 1);
        RETURN;
    END

    IF @Barcode IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Products WHERE Barcode = @Barcode)
    BEGIN
        RAISERROR(N'Mã vạch đã tồn tại.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.Products(Name, BrandId, UnitId, Price, Quantity, Barcode, Image, Description)
    VALUES (@Name, @BrandId, @UnitId, @Price, 0, @Barcode, @Image, @Description);

    SELECT * FROM dbo.Products WHERE ProductId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CreateImportReceipt
    @SupplierId INT = NULL,
    @SupplierContactId INT = NULL,
    @Total DECIMAL(10,2),
    @PaidAmount DECIMAL(10,2),
    @Note NVARCHAR(255) = NULL,
    @CreatedByAdminId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.Users
        WHERE UserId = @CreatedByAdminId AND Role = 'Admin' AND Status = 'Active'
    )
    BEGIN
        RAISERROR(N'Chỉ Admin mới được tạo phiếu nhập hàng.', 16, 1);
        RETURN;
    END

    IF @SupplierId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.Suppliers WHERE SupplierId = @SupplierId)
    BEGIN
        RAISERROR(N'Nhà cung cấp không tồn tại.', 16, 1);
        RETURN;
    END

    IF @SupplierContactId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.SupplierContacts WHERE ContactId = @SupplierContactId)
    BEGIN
        RAISERROR(N'Người liên hệ không tồn tại.', 16, 1);
        RETURN;
    END

    IF @Total < 0 OR @PaidAmount < 0 OR @PaidAmount > @Total
    BEGIN
        RAISERROR(N'Tổng tiền hoặc số tiền đã trả không hợp lệ.', 16, 1);
        RETURN;
    END

    DECLARE @DebtAmount DECIMAL(10,2) = @Total - @PaidAmount;
    DECLARE @Status NVARCHAR(20) = CASE
        WHEN @Total = 0 THEN 'Draft'
        WHEN @PaidAmount = 0 THEN 'Unpaid'
        WHEN @PaidAmount < @Total THEN 'PartialPaid'
        ELSE 'Completed'
    END;

    INSERT INTO dbo.ImportReceipts([Date], Total, SupplierId, SupplierContactId, ContactId, PaidAmount, DebtAmount, Status, Note, CreatedByAdminId)
    VALUES (GETDATE(), @Total, @SupplierId, @SupplierContactId, @SupplierContactId, @PaidAmount, @DebtAmount, @Status, @Note, @CreatedByAdminId);

    DECLARE @NewImportId INT = SCOPE_IDENTITY();
    UPDATE dbo.ImportReceipts
    SET ImportCode = N'IMP' + RIGHT('000000' + CAST(@NewImportId AS VARCHAR(10)), 6)
    WHERE ImportId = @NewImportId;

    SELECT * FROM dbo.ImportReceipts WHERE ImportId = @NewImportId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddImportDetail
    @ImportId INT,
    @ProductId INT,
    @Quantity INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ImportReceipts WHERE ImportId = @ImportId)
    BEGIN
        RAISERROR(N'Phiếu nhập không tồn tại.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Products WHERE ProductId = @ProductId)
    BEGIN
        RAISERROR(N'Sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END

    IF @Quantity <= 0 OR @Price < 0
    BEGIN
        RAISERROR(N'Số lượng hoặc giá nhập không hợp lệ.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.ImportDetails(ImportId, ProductId, Quantity, Price)
    VALUES (@ImportId, @ProductId, @Quantity, @Price);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RecalculateImportReceipt
    @ImportId INT,
    @PaidAmount DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.ImportReceipts WHERE ImportId = @ImportId)
    BEGIN
        RAISERROR(N'Phiếu nhập không tồn tại.', 16, 1);
        RETURN;
    END

    DECLARE @Total DECIMAL(10,2) = 0;
    DECLARE @CurrentPaid DECIMAL(10,2);

    SELECT @Total = ISNULL(SUM(Quantity * Price), 0)
    FROM dbo.ImportDetails
    WHERE ImportId = @ImportId;

    SELECT @CurrentPaid = PaidAmount
    FROM dbo.ImportReceipts
    WHERE ImportId = @ImportId;

    IF @PaidAmount IS NULL SET @PaidAmount = ISNULL(@CurrentPaid, 0);
    IF @PaidAmount < 0 OR @PaidAmount > @Total
    BEGIN
        RAISERROR(N'Số tiền đã trả không hợp lệ.', 16, 1);
        RETURN;
    END

    UPDATE dbo.ImportReceipts
    SET Total = @Total,
        PaidAmount = @PaidAmount,
        DebtAmount = @Total - @PaidAmount,
        Status = CASE
            WHEN @Total = 0 THEN 'Draft'
            WHEN @PaidAmount = 0 THEN 'Unpaid'
            WHEN @PaidAmount < @Total THEN 'PartialPaid'
            ELSE 'Completed'
        END
    WHERE ImportId = @ImportId;

    SELECT * FROM dbo.ImportReceipts WHERE ImportId = @ImportId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegisterShift
    @UserId INT,
    @ShiftId INT,
    @WorkDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @UserId AND Status = 'Active')
    BEGIN
        RAISERROR(N'Nhân viên không hợp lệ.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.WorkShifts WHERE ShiftId = @ShiftId)
    BEGIN
        RAISERROR(N'Ca làm không tồn tại.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.UserShifts WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate)
    BEGIN
        RAISERROR(N'Bạn đã đăng ký ca này rồi.', 16, 1);
        RETURN;
    END

    DECLARE @MaxStaff INT;
    SELECT @MaxStaff = MaxStaff FROM dbo.WorkShifts WHERE ShiftId = @ShiftId;

    IF (SELECT COUNT(*) FROM dbo.UserShifts WHERE ShiftId = @ShiftId AND WorkDate = @WorkDate) >= @MaxStaff
    BEGIN
        RAISERROR(N'Ca này đã đủ số lượng nhân viên.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.UserShifts(UserId, ShiftId, WorkDate) VALUES (@UserId, @ShiftId, @WorkDate);
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CheckInShift
    @UserId INT,
    @ShiftId INT,
    @WorkDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.UserShifts WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate)
    BEGIN
        RAISERROR(N'Bạn chưa đăng ký ca này.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Attendances WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate AND CheckIn IS NOT NULL)
    BEGIN
        RAISERROR(N'Bạn đã check-in ca này rồi.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.Attendances(UserId, ShiftId, WorkDate, CheckIn)
    VALUES (@UserId, @ShiftId, @WorkDate, GETDATE());
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CheckOutShift
    @UserId INT,
    @ShiftId INT,
    @WorkDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Attendances WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate AND CheckIn IS NOT NULL)
    BEGIN
        RAISERROR(N'Bạn chưa check-in ca này.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Attendances WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate AND CheckOut IS NOT NULL)
    BEGIN
        RAISERROR(N'Bạn đã check-out ca này rồi.', 16, 1);
        RETURN;
    END

    UPDATE dbo.Attendances
    SET CheckOut = GETDATE()
    WHERE UserId = @UserId AND ShiftId = @ShiftId AND WorkDate = @WorkDate;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ApprovePendingUser
    @PendingId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.PendingUsers WHERE Id = @PendingId AND Status = 'Pending')
        BEGIN
            RAISERROR(N'Tài khoản chờ duyệt không tồn tại hoặc không ở trạng thái Pending.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @Username NVARCHAR(50), @Password NVARCHAR(255), @FullName NVARCHAR(100), @Phone NVARCHAR(20), @Email NVARCHAR(100);
        SELECT @Username = Username, @Password = Password, @FullName = FullName, @Phone = Phone, @Email = Email
        FROM dbo.PendingUsers WHERE Id = @PendingId;

        IF EXISTS (SELECT 1 FROM dbo.Users WHERE Username = @Username)
        BEGIN
            RAISERROR(N'Username đã tồn tại trong bảng Users.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @Phone IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Users WHERE Phone = @Phone)
        BEGIN
            RAISERROR(N'Số điện thoại đã tồn tại trong hệ thống.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO dbo.Users(Username, Password, FullName, Phone, Email, Role, Status, Experience, LevelId, CreatedAt)
        VALUES (@Username, @Password, @FullName, @Phone, @Email, 'Staff', 'Active', 0, NULL, GETDATE());

        UPDATE dbo.PendingUsers SET Status = 'Approved' WHERE Id = @PendingId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RejectPendingUser
    @PendingId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.PendingUsers WHERE Id = @PendingId AND Status = 'Pending')
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại hoặc không ở trạng thái Pending.', 16, 1);
        RETURN;
    END

    UPDATE dbo.PendingUsers SET Status = 'Rejected' WHERE Id = @PendingId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegisterPendingUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(255),
    @FullName NVARCHAR(100),
    @Phone NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.Users WHERE Username = @Username)
    BEGIN
        RAISERROR(N'Tên đăng nhập đã tồn tại trong hệ thống.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.PendingUsers WHERE Username = @Username AND Status = 'Pending')
    BEGIN
        RAISERROR(N'Tài khoản này đang chờ duyệt, không thể đăng ký lại.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.PendingUsers(Username, Password, FullName, Phone, Email, Status)
    VALUES (@Username, @Password, @FullName, @Phone, @Email, 'Pending');
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetTrainerLevels
AS
BEGIN
    SET NOCOUNT ON;
    SELECT LevelId, Name, MinExperience, MaxExperience, PricePercentIncrease
    FROM dbo.TrainerLevels
    ORDER BY MinExperience, LevelId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddTrainer
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Experience INT,
    @SalaryPercent INT,
    @Status NVARCHAR(20),
    @Avatar NVARCHAR(255) = NULL,
    @Specialty NVARCHAR(100) = NULL,
    @LevelId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF LTRIM(RTRIM(ISNULL(@Name, N''))) = N''
    BEGIN RAISERROR(N'Tên huấn luyện viên không được để trống.', 16, 1); RETURN; END
    IF @Experience < 0
    BEGIN RAISERROR(N'Kinh nghiệm không hợp lệ.', 16, 1); RETURN; END
    IF @SalaryPercent < 0 OR @SalaryPercent > 100
    BEGIN RAISERROR(N'Phần trăm lương không hợp lệ.', 16, 1); RETURN; END
    IF @Status NOT IN ('Active','Inactive')
    BEGIN RAISERROR(N'Trạng thái không hợp lệ.', 16, 1); RETURN; END
    IF @LevelId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.TrainerLevels WHERE LevelId = @LevelId)
    BEGIN RAISERROR(N'Cấp độ huấn luyện viên không tồn tại.', 16, 1); RETURN; END

    INSERT INTO dbo.Trainers(Name, Phone, Email, Experience, SalaryPercent, Status, Avatar, Specialty, LevelId, CreatedAt)
    VALUES (@Name, @Phone, @Email, @Experience, @SalaryPercent, @Status, @Avatar, @Specialty, @LevelId, GETDATE());

    SELECT * FROM dbo.Trainers WHERE TrainerId = SCOPE_IDENTITY();
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_UpdateTrainer
    @TrainerId INT,
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Experience INT,
    @SalaryPercent INT,
    @Status NVARCHAR(20),
    @Avatar NVARCHAR(255) = NULL,
    @Specialty NVARCHAR(100) = NULL,
    @LevelId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Trainers WHERE TrainerId = @TrainerId)
    BEGIN RAISERROR(N'Huấn luyện viên không tồn tại.', 16, 1); RETURN; END

    UPDATE dbo.Trainers
    SET Name = @Name,
        Phone = @Phone,
        Email = @Email,
        Experience = @Experience,
        SalaryPercent = @SalaryPercent,
        Status = @Status,
        Avatar = @Avatar,
        Specialty = @Specialty,
        LevelId = @LevelId,
        UpdatedAt = GETDATE()
    WHERE TrainerId = @TrainerId;

    SELECT * FROM dbo.Trainers WHERE TrainerId = @TrainerId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_SetTrainerStatus
    @TrainerId INT,
    @Status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Trainers WHERE TrainerId = @TrainerId)
    BEGIN RAISERROR(N'Huấn luyện viên không tồn tại.', 16, 1); RETURN; END
    IF @Status NOT IN ('Active','Inactive')
    BEGIN RAISERROR(N'Trạng thái không hợp lệ.', 16, 1); RETURN; END

    UPDATE dbo.Trainers SET Status = @Status, UpdatedAt = GETDATE() WHERE TrainerId = @TrainerId;
    SELECT * FROM dbo.Trainers WHERE TrainerId = @TrainerId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetTrainerList
    @Keyword NVARCHAR(100) = N'',
    @Status NVARCHAR(20) = N'',
    @LevelId INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.TrainerId,
        t.Name,
        t.Phone,
        t.Email,
        t.Experience,
        t.SalaryPercent,
        t.Status,
        t.Avatar,
        t.Specialty,
        t.LevelId,
        ISNULL(tl.Name, N'') AS LevelName,
        ISNULL(tl.PricePercentIncrease, 0) AS PricePercentIncrease,
        (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId AND m.Status = 'Active' AND m.EndDate >= CAST(GETDATE() AS DATE)) AS ActiveClients,
        (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalClients,
        (SELECT ISNULL(SUM(m.Price), 0) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalRevenue,
        t.CreatedAt,
        t.UpdatedAt
    FROM dbo.Trainers t
    LEFT JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
    WHERE (@Keyword = N'' OR t.Name LIKE N'%' + @Keyword + N'%' OR ISNULL(t.Phone, N'') LIKE N'%' + @Keyword + N'%' OR ISNULL(t.Specialty, N'') LIKE N'%' + @Keyword + N'%')
      AND (@Status = N'' OR t.Status = @Status)
      AND (@LevelId = 0 OR ISNULL(t.LevelId, 0) = @LevelId)
    ORDER BY t.Name;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetTrainerById
    @TrainerId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Trainers WHERE TrainerId = @TrainerId)
    BEGIN RAISERROR(N'Huấn luyện viên không tồn tại.', 16, 1); RETURN; END

    SELECT
        t.TrainerId,
        t.Name,
        t.Phone,
        t.Email,
        t.Experience,
        t.SalaryPercent,
        t.Status,
        t.Avatar,
        t.Specialty,
        t.LevelId,
        ISNULL(tl.Name, N'') AS LevelName,
        ISNULL(tl.PricePercentIncrease, 0) AS PricePercentIncrease,
        (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId AND m.Status = 'Active' AND m.EndDate >= CAST(GETDATE() AS DATE)) AS ActiveClients,
        (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalClients,
        (SELECT ISNULL(SUM(m.Price), 0) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalRevenue,
        t.CreatedAt,
        t.UpdatedAt
    FROM dbo.Trainers t
    LEFT JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
    WHERE t.TrainerId = @TrainerId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetTrainerMembers
    @TrainerId INT,
    @MembershipStatus NVARCHAR(20) = N''
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Trainers WHERE TrainerId = @TrainerId)
    BEGIN RAISERROR(N'Huấn luyện viên không tồn tại.', 16, 1); RETURN; END

    SELECT
        m.MembershipId,
        c.CustomerId,
        c.FullName,
        c.Phone,
        p.PackageId,
        p.Name AS PackageName,
        m.StartDate,
        m.EndDate,
        m.Status,
        m.Price,
        m.CreatedAt
    FROM dbo.Memberships m
    JOIN dbo.Customers c ON m.CustomerId = c.CustomerId
    JOIN dbo.Packages p ON m.PackageId = p.PackageId
    WHERE m.TrainerId = @TrainerId
      AND (@MembershipStatus = N'' OR m.Status = @MembershipStatus)
    ORDER BY m.StartDate DESC, m.MembershipId DESC;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegisterMembership
    @CustomerId INT,
    @PackageId INT,
    @TrainerId INT = NULL,
    @StartDate DATE,
    @Avatar NVARCHAR(255) = NULL,
    @IdentityNumber NVARCHAR(50) = NULL,
    @CardCode NVARCHAR(50) = NULL,
    @CreatedByStaffId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @CreatedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người tạo không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE CustomerId = @CustomerId)
        BEGIN RAISERROR(N'Khách hàng không tồn tại.', 16, 1); ROLLBACK; RETURN; END
        IF EXISTS (SELECT 1 FROM dbo.Memberships WHERE CustomerId = @CustomerId AND EndDate > @StartDate AND Status IN ('Pending','Active'))
        BEGIN RAISERROR(N'Khách còn gói tập chưa hết.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @DurationValue INT, @DurationType NVARCHAR(20), @BasePrice DECIMAL(10,2), @FinalPrice DECIMAL(10,2), @EndDate DATE, @Increase INT = 0, @NewMembershipId INT;
        SELECT @DurationValue = DurationValue, @DurationType = DurationType, @BasePrice = Price FROM dbo.Packages WHERE PackageId = @PackageId;
        IF @BasePrice IS NULL
        BEGIN RAISERROR(N'Gói tập không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        SET @EndDate = CASE @DurationType
            WHEN 'Day' THEN DATEADD(DAY, @DurationValue, @StartDate)
            WHEN 'Month' THEN DATEADD(MONTH, @DurationValue, @StartDate)
            WHEN 'Year' THEN DATEADD(YEAR, @DurationValue, @StartDate)
        END;

        IF @TrainerId IS NOT NULL
        BEGIN
            SELECT @Increase = ISNULL(tl.PricePercentIncrease, 0)
            FROM dbo.Trainers t
            JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
            WHERE t.TrainerId = @TrainerId;
        END

        SET @FinalPrice = @BasePrice * (1 + @Increase / 100.0);

        IF @CardCode IS NULL OR LTRIM(RTRIM(@CardCode)) = N''
        BEGIN
            DECLARE @Next INT;
            SELECT @Next = ISNULL(MAX(TRY_CAST(SUBSTRING(CardCode, 5, LEN(CardCode)) AS INT)), 0) + 1
            FROM dbo.MemberProfiles WITH (UPDLOCK, HOLDLOCK)
            WHERE CardCode LIKE 'CARD%';
            SET @CardCode = N'CARD' + RIGHT('0000' + CAST(@Next AS VARCHAR(10)), 4);
        END

        IF NOT EXISTS (SELECT 1 FROM dbo.MemberProfiles WHERE CustomerId = @CustomerId)
        BEGIN
            INSERT INTO dbo.MemberProfiles(CustomerId, Avatar, IdentityNumber, CardCode, JoinDate, Status)
            VALUES (@CustomerId, @Avatar, @IdentityNumber, @CardCode, @StartDate, 'Active');
        END
        ELSE
        BEGIN
            UPDATE dbo.MemberProfiles
            SET Avatar = ISNULL(@Avatar, Avatar),
                IdentityNumber = ISNULL(@IdentityNumber, IdentityNumber),
                CardCode = ISNULL(@CardCode, CardCode),
                Status = 'Active'
            WHERE CustomerId = @CustomerId;
        END

        INSERT INTO dbo.Memberships(CustomerId, PackageId, TrainerId, StartDate, EndDate, Status, Price, CreatedAt, CreatedByStaffId)
        VALUES (@CustomerId, @PackageId, @TrainerId, @StartDate, @EndDate, 'Pending', @FinalPrice, GETDATE(), @CreatedByStaffId);

        SET @NewMembershipId = SCOPE_IDENTITY();
        COMMIT;
        SELECT @NewMembershipId AS NewMembershipId;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RenewMembership
    @CustomerId INT,
    @PackageId INT,
    @TrainerId INT = NULL,
    @StartDate DATE,
    @CreatedByStaffId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @CreatedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người gia hạn không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE CustomerId = @CustomerId)
        BEGIN RAISERROR(N'Khách hàng không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @DurationValue INT, @DurationType NVARCHAR(20), @BasePrice DECIMAL(10,2), @FinalPrice DECIMAL(10,2), @EndDate DATE, @Increase INT = 0, @NewMembershipId INT;
        SELECT @DurationValue = DurationValue, @DurationType = DurationType, @BasePrice = Price FROM dbo.Packages WHERE PackageId = @PackageId;
        IF @BasePrice IS NULL
        BEGIN RAISERROR(N'Gói tập không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        SET @EndDate = CASE @DurationType
            WHEN 'Day' THEN DATEADD(DAY, @DurationValue, @StartDate)
            WHEN 'Month' THEN DATEADD(MONTH, @DurationValue, @StartDate)
            WHEN 'Year' THEN DATEADD(YEAR, @DurationValue, @StartDate)
        END;

        IF @TrainerId IS NOT NULL
        BEGIN
            SELECT @Increase = ISNULL(tl.PricePercentIncrease, 0)
            FROM dbo.Trainers t JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
            WHERE t.TrainerId = @TrainerId;
        END

        SET @FinalPrice = @BasePrice * (1 + @Increase / 100.0);

        INSERT INTO dbo.Memberships(CustomerId, PackageId, TrainerId, StartDate, EndDate, Status, Price, CreatedAt, CreatedByStaffId)
        VALUES (@CustomerId, @PackageId, @TrainerId, @StartDate, @EndDate, 'Pending', @FinalPrice, GETDATE(), @CreatedByStaffId);

        SET @NewMembershipId = SCOPE_IDENTITY();
        COMMIT;
        SELECT @NewMembershipId AS NewMembershipId;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_PayMembership
    @MembershipId INT,
    @Amount DECIMAL(10,2),
    @Method NVARCHAR(20),
    @CashReceived DECIMAL(10,2) = NULL,
    @Note NVARCHAR(255) = NULL,
    @ReceivedByStaffId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @ReceivedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người thu tiền phải là Staff hoặc Admin đang hoạt động.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @MembershipPrice DECIMAL(10,2), @PaidAmount DECIMAL(10,2) = 0, @Change DECIMAL(10,2) = NULL;
        SELECT @MembershipPrice = Price FROM dbo.Memberships WHERE MembershipId = @MembershipId;
        IF @MembershipPrice IS NULL
        BEGIN RAISERROR(N'Không tìm thấy membership.', 16, 1); ROLLBACK; RETURN; END

        SELECT @PaidAmount = ISNULL(SUM(Amount), 0) FROM dbo.MembershipPayments WHERE MembershipId = @MembershipId;

        IF @Method NOT IN ('Cash','Online')
        BEGIN RAISERROR(N'Phương thức thanh toán không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF @Amount <= 0
        BEGIN RAISERROR(N'Số tiền thanh toán không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF @PaidAmount + @Amount < @MembershipPrice
        BEGIN RAISERROR(N'Số tiền thanh toán chưa đủ.', 16, 1); ROLLBACK; RETURN; END
        IF @PaidAmount + @Amount > @MembershipPrice
        BEGIN RAISERROR(N'Số tiền thanh toán vượt quá giá gói.', 16, 1); ROLLBACK; RETURN; END

        IF @Method = 'Cash'
        BEGIN
            IF @CashReceived IS NULL OR @CashReceived < @Amount
            BEGIN RAISERROR(N'Số tiền khách đưa không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
            SET @Change = @CashReceived - @Amount;
        END
        ELSE
        BEGIN
            SET @CashReceived = NULL;
            SET @Change = NULL;
        END

        INSERT INTO dbo.MembershipPayments(MembershipId, Amount, PaymentDate, Method, CashReceived, ChangeAmount, Note, ReceivedByStaffId)
        VALUES (@MembershipId, @Amount, GETDATE(), @Method, @CashReceived, @Change, @Note, @ReceivedByStaffId);

        UPDATE dbo.Memberships SET Status = 'Active' WHERE MembershipId = @MembershipId AND Status = 'Pending';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CheckinMember
    @CardCode NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Today DATE = CAST(GETDATE() AS DATE), @CustomerId INT, @MembershipId INT;

    SELECT @CustomerId = mp.CustomerId FROM dbo.MemberProfiles mp WHERE mp.CardCode = @CardCode;
    IF @CustomerId IS NULL
    BEGIN RAISERROR(N'Không tìm thấy hội viên với mã thẻ này.', 16, 1); RETURN; END

    SELECT TOP 1 @MembershipId = m.MembershipId
    FROM dbo.Memberships m
    WHERE m.CustomerId = @CustomerId AND m.Status = 'Active' AND @Today BETWEEN m.StartDate AND m.EndDate
    ORDER BY m.MembershipId DESC;

    IF @MembershipId IS NULL
    BEGIN RAISERROR(N'Hội viên không có gói đang hoạt động hoặc gói đã hết hạn.', 16, 1); RETURN; END

    IF EXISTS (SELECT 1 FROM dbo.Checkins WHERE MembershipId = @MembershipId AND CustomerId = @CustomerId AND CAST(CheckinTime AS DATE) = @Today)
    BEGIN RAISERROR(N'Hội viên đã check-in hôm nay.', 16, 1); RETURN; END

    INSERT INTO dbo.Checkins(CustomerId, MembershipId, CheckinTime)
    VALUES (@CustomerId, @MembershipId, GETDATE());

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewCheckinId;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CheckoutSalesInvoice
    @CustomerId INT = NULL,
    @DiscountPercent DECIMAL(10,2) = 0,
    @DiscountAmount DECIMAL(10,2) = 0,
    @Note NVARCHAR(255) = NULL,
    @CreatedByStaffId INT,
    @PaymentMethod NVARCHAR(20),
    @CashReceived DECIMAL(10,2) = NULL,
    @Items dbo.SalesCheckoutItemType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @CreatedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người lập hóa đơn phải là Staff hoặc Admin đang hoạt động.', 16, 1); ROLLBACK; RETURN; END
        IF @PaymentMethod NOT IN ('Cash','Online')
        BEGIN RAISERROR(N'Phương thức thanh toán không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF NOT EXISTS (SELECT 1 FROM @Items)
        BEGIN RAISERROR(N'Giỏ hàng trống.', 16, 1); ROLLBACK; RETURN; END
        IF EXISTS (SELECT 1 FROM @Items WHERE Quantity <= 0 OR Price < 0)
        BEGIN RAISERROR(N'Dữ liệu sản phẩm trong giỏ hàng không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF EXISTS (SELECT 1 FROM @Items i LEFT JOIN dbo.Products p ON p.ProductId = i.ProductId WHERE p.ProductId IS NULL)
        BEGIN RAISERROR(N'Có sản phẩm không tồn tại trong hệ thống.', 16, 1); ROLLBACK; RETURN; END
        IF EXISTS (SELECT 1 FROM @Items i JOIN dbo.Products p ON p.ProductId = i.ProductId WHERE i.Quantity > p.Quantity)
        BEGIN RAISERROR(N'Không đủ hàng trong kho để thanh toán.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @SubTotal DECIMAL(10,2), @FinalTotal DECIMAL(10,2), @SalesInvoiceId INT, @ChangeAmount DECIMAL(10,2) = NULL;
        SELECT @SubTotal = ISNULL(SUM(Quantity * Price), 0) FROM @Items;

        IF @DiscountPercent < 0 OR @DiscountAmount < 0
        BEGIN RAISERROR(N'Giảm giá không hợp lệ.', 16, 1); ROLLBACK; RETURN; END

        SET @FinalTotal = @SubTotal - (@SubTotal * @DiscountPercent / 100.0) - @DiscountAmount;
        IF @FinalTotal < 0 SET @FinalTotal = 0;

        IF @PaymentMethod = 'Cash'
        BEGIN
            IF @CashReceived IS NULL OR @CashReceived < @FinalTotal
            BEGIN RAISERROR(N'Số tiền khách đưa không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
            SET @ChangeAmount = @CashReceived - @FinalTotal;
        END
        ELSE
        BEGIN
            SET @CashReceived = NULL;
            SET @ChangeAmount = NULL;
        END

        INSERT INTO dbo.SalesInvoices(CustomerId, InvoiceDate, Total, Note, CreatedByStaffId)
        VALUES (@CustomerId, GETDATE(), @FinalTotal, @Note, @CreatedByStaffId);
        SET @SalesInvoiceId = SCOPE_IDENTITY();

        INSERT INTO dbo.SalesInvoiceDetails(SalesInvoiceId, ProductId, Quantity, Price)
        SELECT @SalesInvoiceId, ProductId, Quantity, Price FROM @Items;

        UPDATE p
        SET p.Quantity = p.Quantity - i.Quantity
        FROM dbo.Products p
        JOIN @Items i ON i.ProductId = p.ProductId;

        INSERT INTO dbo.SalesPayments(SalesInvoiceId, Amount, PaymentDate, Method, CashReceived, ChangeAmount, ReceivedByStaffId)
        VALUES (@SalesInvoiceId, @FinalTotal, GETDATE(), @PaymentMethod, @CashReceived, @ChangeAmount, @CreatedByStaffId);

        COMMIT TRANSACTION;
        SELECT @SalesInvoiceId AS NewSalesInvoiceId;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

/* =========================================================
   5. VIEW
========================================================= */
CREATE OR ALTER VIEW dbo.vw_Trainers_Admin
AS
SELECT
    t.TrainerId,
    t.Name,
    t.Phone,
    t.Email,
    t.Experience,
    t.SalaryPercent,
    t.Status,
    t.Avatar,
    t.Specialty,
    t.LevelId,
    ISNULL(tl.Name, N'') AS LevelName,
    ISNULL(tl.PricePercentIncrease, 0) AS PricePercentIncrease,
    (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId AND m.Status = 'Active' AND m.EndDate >= CAST(GETDATE() AS DATE)) AS ActiveClients,
    (SELECT COUNT(*) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalClients,
    (SELECT ISNULL(SUM(m.Price), 0) FROM dbo.Memberships m WHERE m.TrainerId = t.TrainerId) AS TotalRevenue,
    t.CreatedAt,
    t.UpdatedAt
FROM dbo.Trainers t
LEFT JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId;
GO

/* =========================================================
   6. SEED DATA
========================================================= */
INSERT INTO dbo.SystemConfig(Id, BaseSalaryPerShift) VALUES (1, 120000);
GO

INSERT INTO dbo.StaffLevels(Name, MinExperience, MaxExperience, SalaryPercentIncrease)
VALUES
(N'Junior', 0, 1, 10),
(N'Mid', 2, 4, 20),
(N'Senior', 5, 10, 30);
GO

INSERT INTO dbo.TrainerLevels(Name, MinExperience, MaxExperience, PricePercentIncrease)
VALUES
(N'Basic', 0, 1, 10),
(N'Pro', 2, 4, 20),
(N'Elite', 5, 10, 30);
GO

/* Mật khẩu hash đang dùng trong project cũ: 123 */
INSERT INTO dbo.Users(Username, Password, FullName, Phone, Email, Role, Status, Experience, LevelId, CreatedAt)
VALUES
(N'admin',  N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Nguyễn Minh Quân', N'0901111111', N'admin@gymfinal.vn', 'Admin', 'Active', 6, 3, DATEADD(DAY, -180, GETDATE())),
(N'staff1', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Trần Văn Hùng',   N'0902222222', N'hung.tran@gymfinal.vn', 'Staff', 'Active', 2, 2, DATEADD(DAY, -120, GETDATE())),
(N'staff2', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Lê Thị Lan',      N'0903333333', N'lan.le@gymfinal.vn', 'Staff', 'Active', 4, 2, DATEADD(DAY, -110, GETDATE())),
(N'staff3', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Phạm Quốc Bảo',   N'0904444444', N'bao.pham@gymfinal.vn', 'Staff', 'Active', 6, 3, DATEADD(DAY, -100, GETDATE())),
(N'staff4', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Đỗ Thu Hà',       N'0905555555', N'ha.do@gymfinal.vn', 'Staff', 'Active', 1, 1, DATEADD(DAY, -60, GETDATE()));
GO

INSERT INTO dbo.PendingUsers(Username, Password, FullName, Phone, Email, Status, CreatedAt)
VALUES
(N'staff_pending1', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Nguyễn Đức Long', N'0919000001', N'long.nguyen@gmail.com', 'Pending', DATEADD(DAY, -2, GETDATE())),
(N'staff_pending2', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'Bùi Khánh Vy',   N'0919000002', N'vy.bui@gmail.com',   'Pending', DATEADD(DAY, -1, GETDATE()));
GO

INSERT INTO dbo.WorkShifts(Name, StartTime, EndTime, MaxStaff)
VALUES
(N'Sáng',  '06:00', '12:00', 3),
(N'Chiều', '12:00', '18:00', 3),
(N'Tối',   '18:00', '22:00', 4);
GO

DECLARE @Today DATE = CAST(GETDATE() AS DATE);

INSERT INTO dbo.UserShifts(UserId, ShiftId, WorkDate)
VALUES
(2, 1, DATEADD(DAY, -2, @Today)), (2, 2, DATEADD(DAY, -1, @Today)), (2, 1, @Today),
(3, 2, DATEADD(DAY, -2, @Today)), (3, 3, DATEADD(DAY, -1, @Today)), (3, 2, @Today),
(4, 1, DATEADD(DAY, -1, @Today)), (4, 3, @Today),
(5, 3, DATEADD(DAY, -2, @Today)), (5, 1, DATEADD(DAY, 1, @Today));
GO

INSERT INTO dbo.Attendances(UserId, ShiftId, WorkDate, CheckIn, CheckOut)
VALUES
(2, 1, DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), DATEADD(HOUR, 6, CAST(DATEADD(DAY, -2, GETDATE()) AS DATETIME)), DATEADD(HOUR, 12, CAST(DATEADD(DAY, -2, GETDATE()) AS DATETIME))),
(2, 2, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), DATEADD(HOUR, 12, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME)), DATEADD(HOUR, 18, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME))),
(3, 2, DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), DATEADD(HOUR, 12, CAST(DATEADD(DAY, -2, GETDATE()) AS DATETIME)), DATEADD(HOUR, 18, CAST(DATEADD(DAY, -2, GETDATE()) AS DATETIME))),
(3, 3, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), DATEADD(HOUR, 18, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME)), DATEADD(HOUR, 22, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME))),
(4, 1, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), DATEADD(HOUR, 6, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME)), DATEADD(HOUR, 12, CAST(DATEADD(DAY, -1, GETDATE()) AS DATETIME)));
GO

INSERT INTO dbo.Customers(FullName, Phone, Address, CreatedAt)
VALUES
(N'Nguyễn Hoàng Anh', N'0912341001', N'Hà Nội', DATEADD(DAY, -50, GETDATE())),
(N'Trần Minh Châu',   N'0912341002', N'Hà Nội', DATEADD(DAY, -48, GETDATE())),
(N'Lê Gia Bảo',       N'0912341003', N'Hải Phòng', DATEADD(DAY, -45, GETDATE())),
(N'Phạm Thu Trang',   N'0912341004', N'Hà Nội', DATEADD(DAY, -40, GETDATE())),
(N'Đặng Quốc Khánh',  N'0912341005', N'Bắc Ninh', DATEADD(DAY, -35, GETDATE())),
(N'Vũ Ngọc Mai',      N'0912341006', N'Hưng Yên', DATEADD(DAY, -30, GETDATE())),
(N'Bùi Thanh Tùng',   N'0912341007', N'Hà Nội', DATEADD(DAY, -28, GETDATE())),
(N'Hoàng Diệu Linh',  N'0912341008', N'Hà Nội', DATEADD(DAY, -24, GETDATE())),
(N'Ngô Đức Nam',      N'0912341009', N'Hà Nam', DATEADD(DAY, -20, GETDATE())),
(N'Phan Khánh Huyền', N'0912341010', N'Hà Nội', DATEADD(DAY, -18, GETDATE())),
(N'Chu Nhật Minh',    N'0912341011', N'Hải Dương', DATEADD(DAY, -14, GETDATE())),
(N'Đỗ Quỳnh Anh',     N'0912341012', N'Hà Nội', DATEADD(DAY, -12, GETDATE())),
(N'Tạ Công Phúc',     N'0912341013', N'Hà Nội', DATEADD(DAY, -8, GETDATE())),
(N'Nguyễn Thanh Thảo',N'0912341014', N'Hà Nội', DATEADD(DAY, -6, GETDATE())),
(N'Lý Gia Hân',       N'0912341015', N'Bắc Giang', DATEADD(DAY, -3, GETDATE()));
GO

INSERT INTO dbo.Trainers(Name, Phone, Email, Experience, SalaryPercent, Status, Avatar, Specialty, LevelId, CreatedAt)
VALUES
(N'Nguyễn Thành Đạt', N'0981111111', N'dat.pt@gymfinal.vn', 1, 20, 'Active', N'trainer_dat.jpg', N'Giảm mỡ', 1, DATEADD(DAY, -90, GETDATE())),
(N'Trần Đức Mạnh',    N'0982222222', N'manh.pt@gymfinal.vn', 3, 25, 'Active', N'trainer_manh.jpg', N'Tăng cơ', 2, DATEADD(DAY, -88, GETDATE())),
(N'Lê Hồng Sơn',      N'0983333333', N'son.pt@gymfinal.vn', 6, 30, 'Active', N'trainer_son.jpg', N'Sức mạnh & body recomposition', 3, DATEADD(DAY, -84, GETDATE())),
(N'Phan Nhật Vy',     N'0984444444', N'vy.pt@gymfinal.vn', 2, 22, 'Active', N'trainer_vy.jpg', N'Yoga & mobility', 2, DATEADD(DAY, -80, GETDATE()));
GO

INSERT INTO dbo.Packages(Name, Price, DurationValue, DurationType, Description)
VALUES
(N'Gói trải nghiệm 7 ngày', 199000, 7, 'Day', N'Gói tập thử cho khách mới'),
(N'Gói 1 tháng',            650000, 1, 'Month', N'Tập gym tự do 1 tháng'),
(N'Gói 3 tháng',           1800000, 3, 'Month', N'Tiết kiệm hơn cho người tập đều'),
(N'Gói 12 tháng',          6200000, 1, 'Year',  N'Gói hội viên dài hạn');
GO

INSERT INTO dbo.Brands(Name)
VALUES (N'Optimum Nutrition'), (N'MuscleTech'), (N'Rule 1'), (N'Applied Nutrition'), (N'Six Star');
GO

INSERT INTO dbo.Units(Name)
VALUES (N'Hộp'), (N'Chai'), (N'Gói'), (N'Cái');
GO

INSERT INTO dbo.Products(Name, BrandId, UnitId, Price, Quantity, Barcode, Image, Description)
VALUES
(N'Gold Standard Whey 5lb', 1, 1, 1650000, 0, N'SP0001', N'whey.jpg', N'Whey protein cao cấp'),
(N'Creatine Monohydrate',   2, 1, 450000,  0, N'SP0002', N'creatine.jpg', N'Hỗ trợ sức mạnh và phục hồi'),
(N'BCAA 2:1:1',             3, 1, 620000,  0, N'SP0003', N'bcaa.jpg', N'Hỗ trợ phục hồi cơ bắp'),
(N'Pre Workout 30 servings',4, 1, 780000,  0, N'SP0004', N'pre.jpg', N'Tăng tập trung trước buổi tập'),
(N'Nước suối Aquafina',     NULL, 2, 12000, 0, N'SP0005', N'water.jpg', N'Nước uống đóng chai'),
(N'Khăn tập Gym',           NULL, 4, 89000, 0, N'PT0006', N'towel.jpg', N'Khăn microfiber thấm hút tốt'),
(N'Bình shaker 700ml',      NULL, 4, 129000,0, N'PT0007', N'shaker.jpg', N'Bình lắc protein');
GO

INSERT INTO dbo.Suppliers(Name, Phone, Email, Address, TaxCode, Note, Status)
VALUES
(N'Công ty TNHH Dinh Dưỡng Thể Hình Việt', N'02435551234', N'contact@nutritionviet.vn', N'Cầu Giấy, Hà Nội', N'0101234567', N'Đối tác nhập whey và creatine', 'Active'),
(N'Công ty CP Fit Supply',                N'02837778888', N'sales@fitsupply.vn',      N'Thủ Đức, TP.HCM', N'0312345678', N'Đối tác phụ kiện và nước uống', 'Active');
GO

INSERT INTO dbo.SupplierContacts(SupplierId, FullName, Phone, Email, Position, IsPrimary, Note, Status)
VALUES
(1, N'Nguyễn Tiến Dũng', N'0909000001', N'dung.nguyen@nutritionviet.vn', N'Sales Manager', 1, N'Liên hệ chính', 'Active'),
(1, N'Trần Gia Linh',    N'0909000002', N'linh.tran@nutritionviet.vn',   N'Account Executive', 0, NULL, 'Active'),
(2, N'Phạm Hải Nam',     N'0909000003', N'nam.pham@fitsupply.vn',        N'Key Account', 1, N'Nhập phụ kiện', 'Active');
GO

/* Phiếu nhập để có tồn kho đẹp */
EXEC dbo.sp_CreateImportReceipt @SupplierId = 1, @SupplierContactId = 1, @Total = 0, @PaidAmount = 0, @Note = N'Nhập tháng trước', @CreatedByAdminId = 1;
EXEC dbo.sp_AddImportDetail @ImportId = 1, @ProductId = 1, @Quantity = 25, @Price = 1380000;
EXEC dbo.sp_AddImportDetail @ImportId = 1, @ProductId = 2, @Quantity = 30, @Price = 320000;
EXEC dbo.sp_AddImportDetail @ImportId = 1, @ProductId = 3, @Quantity = 18, @Price = 470000;
EXEC dbo.sp_RecalculateImportReceipt @ImportId = 1, @PaidAmount = 25000000;

EXEC dbo.sp_CreateImportReceipt @SupplierId = 2, @SupplierContactId = 3, @Total = 0, @PaidAmount = 0, @Note = N'Nhập phụ kiện và nước', @CreatedByAdminId = 1;
EXEC dbo.sp_AddImportDetail @ImportId = 2, @ProductId = 4, @Quantity = 20, @Price = 610000;
EXEC dbo.sp_AddImportDetail @ImportId = 2, @ProductId = 5, @Quantity = 200, @Price = 7000;
EXEC dbo.sp_AddImportDetail @ImportId = 2, @ProductId = 6, @Quantity = 40, @Price = 45000;
EXEC dbo.sp_AddImportDetail @ImportId = 2, @ProductId = 7, @Quantity = 35, @Price = 70000;
EXEC dbo.sp_RecalculateImportReceipt @ImportId = 2, @PaidAmount = 17850000;
GO

/* Hồ sơ hội viên */
INSERT INTO dbo.MemberProfiles(CustomerId, Avatar, IdentityNumber, CardCode, JoinDate, Status)
VALUES
(1, N'members/member_1.jpg', N'001234567890', N'CARD0001', DATEADD(DAY, -45, CAST(GETDATE() AS DATE)), 'Active'),
(2, N'members/member_2.jpg', N'001234567891', N'CARD0002', DATEADD(DAY, -44, CAST(GETDATE() AS DATE)), 'Active'),
(3, N'members/member_3.jpg', N'001234567892', N'CARD0003', DATEADD(DAY, -40, CAST(GETDATE() AS DATE)), 'Active'),
(4, N'members/member_4.jpg', N'001234567893', N'CARD0004', DATEADD(DAY, -35, CAST(GETDATE() AS DATE)), 'Active'),
(5, N'members/member_5.jpg', N'001234567894', N'CARD0005', DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), 'Active'),
(6, N'members/member_6.jpg', N'001234567895', N'CARD0006', DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), 'Active'),
(7, N'members/member_7.jpg', N'001234567896', N'CARD0007', DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), 'Active'),
(8, N'members/member_8.jpg', N'001234567897', N'CARD0008', DATEADD(DAY, -16, CAST(GETDATE() AS DATE)), 'Active'),
(9, N'members/member_9.jpg', N'001234567898', N'CARD0009', DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), 'Active'),
(10,N'members/member_10.jpg',N'001234567899', N'CARD0010', DATEADD(DAY, -9, CAST(GETDATE() AS DATE)), 'Active');
GO

INSERT INTO dbo.Memberships(CustomerId, PackageId, TrainerId, StartDate, EndDate, Status, Price, CreatedAt, CreatedByStaffId)
VALUES
(1, 2, NULL, DATEADD(DAY, -45, CAST(GETDATE() AS DATE)), DATEADD(DAY, -15, CAST(GETDATE() AS DATE)), 'Expired', 650000, DATEADD(DAY, -45, GETDATE()), 2),
(2, 3, 2,    DATEADD(DAY, -44, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 3, DATEADD(DAY, -44, CAST(GETDATE() AS DATE))), 'Active', 2160000, DATEADD(DAY, -44, GETDATE()), 2),
(3, 4, 3,    DATEADD(DAY, -40, CAST(GETDATE() AS DATE)), DATEADD(YEAR, 1, DATEADD(DAY, -40, CAST(GETDATE() AS DATE))), 'Active', 8060000, DATEADD(DAY, -40, GETDATE()), 3),
(4, 2, NULL, DATEADD(DAY, -35, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -35, CAST(GETDATE() AS DATE))), 'Expired', 650000, DATEADD(DAY, -35, GETDATE()), 3),
(5, 2, 1,    DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -30, CAST(GETDATE() AS DATE))), 'Active', 715000, DATEADD(DAY, -30, GETDATE()), 4),
(6, 3, 4,    DATEADD(DAY, -25, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 3, DATEADD(DAY, -25, CAST(GETDATE() AS DATE))), 'Active', 2160000, DATEADD(DAY, -25, GETDATE()), 4),
(7, 2, NULL, DATEADD(DAY, -20, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -20, CAST(GETDATE() AS DATE))), 'Active', 650000, DATEADD(DAY, -20, GETDATE()), 5),
(8, 1, NULL, DATEADD(DAY, -16, CAST(GETDATE() AS DATE)), DATEADD(DAY, 7, DATEADD(DAY, -16, CAST(GETDATE() AS DATE))), 'Expired', 199000, DATEADD(DAY, -16, GETDATE()), 2),
(9, 2, 2,    DATEADD(DAY, -12, CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -12, CAST(GETDATE() AS DATE))), 'Active', 780000, DATEADD(DAY, -12, GETDATE()), 3),
(10,2, NULL, DATEADD(DAY, -9,  CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -9,  CAST(GETDATE() AS DATE))), 'Active', 650000, DATEADD(DAY, -9,  GETDATE()), 5),
(11,2, NULL, DATEADD(DAY, -4,  CAST(GETDATE() AS DATE)), DATEADD(MONTH, 1, DATEADD(DAY, -4,  CAST(GETDATE() AS DATE))), 'Pending', 650000, DATEADD(DAY, -4,  GETDATE()), 2),
(12,3, 1,    DATEADD(DAY, -2,  CAST(GETDATE() AS DATE)), DATEADD(MONTH, 3, DATEADD(DAY, -2,  CAST(GETDATE() AS DATE))), 'Pending', 1980000, DATEADD(DAY, -2,  GETDATE()), 4);
GO

INSERT INTO dbo.MembershipPayments(MembershipId, Amount, PaymentDate, Method, CashReceived, ChangeAmount, Note, ReceivedByStaffId)
VALUES
(1, 650000, DATEADD(DAY, -45, GETDATE()), 'Cash',   700000, 50000, N'Thanh toán gói 1 tháng', 2),
(2,2160000, DATEADD(DAY, -44, GETDATE()), 'Online', NULL,   NULL,  N'Thanh toán online', 2),
(3,8060000, DATEADD(DAY, -40, GETDATE()), 'Online', NULL,   NULL,  N'Gói 12 tháng + PT Elite', 3),
(4, 650000, DATEADD(DAY, -35, GETDATE()), 'Cash',   700000, 50000, N'Gói 1 tháng', 3),
(5, 715000, DATEADD(DAY, -30, GETDATE()), 'Cash',   800000, 85000, N'Gói 1 tháng có PT', 4),
(6,2160000, DATEADD(DAY, -25, GETDATE()), 'Online', NULL,   NULL,  N'Gói 3 tháng PT', 4),
(7, 650000, DATEADD(DAY, -20, GETDATE()), 'Cash',   650000, 0,     N'Thanh toán đủ', 5),
(8, 199000, DATEADD(DAY, -16, GETDATE()), 'Cash',   200000, 1000,  N'Gói trải nghiệm', 2),
(9, 780000, DATEADD(DAY, -12, GETDATE()), 'Online', NULL,   NULL,  N'Có PT Pro', 3),
(10,650000, DATEADD(DAY, -9,  GETDATE()), 'Cash',   700000, 50000, N'Khách mới', 5);
GO

INSERT INTO dbo.Checkins(CustomerId, MembershipId, CheckinTime)
VALUES
(2, 2, DATEADD(DAY, -5, DATEADD(HOUR, 7, CAST(CAST(GETDATE() AS DATE) AS DATETIME)))),
(3, 3, DATEADD(DAY, -4, DATEADD(HOUR, 18, CAST(CAST(GETDATE() AS DATE) AS DATETIME)))),
(5, 5, DATEADD(DAY, -3, DATEADD(HOUR, 6, CAST(CAST(GETDATE() AS DATE) AS DATETIME)))),
(6, 6, DATEADD(DAY, -2, DATEADD(HOUR, 19, CAST(CAST(GETDATE() AS DATE) AS DATETIME)))),
(7, 7, DATEADD(DAY, -1, DATEADD(HOUR, 17, CAST(CAST(GETDATE() AS DATE) AS DATETIME)))),
(9, 9, DATEADD(HOUR, 8, CAST(CAST(GETDATE() AS DATE) AS DATETIME)));
GO

/* Lịch PT */
INSERT INTO dbo.PTSchedules(MembershipId, CustomerId, TrainerId, ScheduledDate, StartTime, EndTime, Status, Note, CreatedByStaffId)
VALUES
(2, 2, 2, DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), '07:00', '08:00', 'Scheduled', N'Buổi thân trên', 2),
(3, 3, 3, DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), '18:00', '19:00', 'Scheduled', N'Leg day', 3),
(5, 5, 1, DATEADD(DAY, 2, CAST(GETDATE() AS DATE)), '06:30', '07:30', 'Scheduled', N'Cardio + core', 4),
(6, 6, 4, DATEADD(DAY, 2, CAST(GETDATE() AS DATE)), '17:30', '18:30', 'Scheduled', N'Mobility', 4),
(9, 9, 2, CAST(GETDATE() AS DATE),                  '19:00', '20:00', 'Done',      N'Đã hoàn thành', 3);
GO

/* Bán hàng gần đây */
DECLARE @Items1 dbo.SalesCheckoutItemType, @Items2 dbo.SalesCheckoutItemType, @Items3 dbo.SalesCheckoutItemType, @Items4 dbo.SalesCheckoutItemType;
INSERT INTO @Items1 VALUES (1,1,1650000),(5,2,12000);
INSERT INTO @Items2 VALUES (2,1,450000),(7,1,129000);
INSERT INTO @Items3 VALUES (5,3,12000),(6,1,89000);
INSERT INTO @Items4 VALUES (4,1,780000),(5,1,12000);
EXEC dbo.sp_CheckoutSalesInvoice @CustomerId = 2,  @DiscountPercent = 5, @DiscountAmount = 0,     @Note = N'Mua whey sau buổi tập', @CreatedByStaffId = 2, @PaymentMethod = 'Cash',   @CashReceived = 1700000, @Items = @Items1;
EXEC dbo.sp_CheckoutSalesInvoice @CustomerId = 5,  @DiscountPercent = 0, @DiscountAmount = 20000, @Note = N'Khách mua creatine + shaker', @CreatedByStaffId = 3, @PaymentMethod = 'Online', @CashReceived = NULL,    @Items = @Items2;
EXEC dbo.sp_CheckoutSalesInvoice @CustomerId = 10, @DiscountPercent = 0, @DiscountAmount = 0,     @Note = N'Khăn tập và nước', @CreatedByStaffId = 4, @PaymentMethod = 'Cash',   @CashReceived = 130000,  @Items = @Items3;
EXEC dbo.sp_CheckoutSalesInvoice @CustomerId = NULL,@DiscountPercent = 0,@DiscountAmount = 0,     @Note = N'Khách lẻ mua pre-workout', @CreatedByStaffId = 5, @PaymentMethod = 'Cash',   @CashReceived = 800000,  @Items = @Items4;
GO

/* Đồng bộ ImportCode cũ nếu có */
UPDATE dbo.ImportReceipts
SET ImportCode = N'IMP' + RIGHT('000000' + CAST(ImportId AS VARCHAR(10)), 6)
WHERE ImportCode IS NULL;
GO

SELECT N'OK' AS [Status], DB_NAME() AS DatabaseName;
GO

use GymManagementFinal
go

update Users
set FullName = N'Trần Ngọc Đức'
where Username = 'admin'

use GymManagementFinal
go

SET NOCOUNT ON;
GO

IF COL_LENGTH('dbo.Packages', 'PackageType') IS NULL
BEGIN
    ALTER TABLE dbo.Packages
    ADD PackageType NVARCHAR(20) NOT NULL CONSTRAINT DF_Packages_PackageType DEFAULT 'NORMAL';
END
GO

IF COL_LENGTH('dbo.Packages', 'TrainerId') IS NULL
BEGIN
    ALTER TABLE dbo.Packages
    ADD TrainerId INT NULL;
END
GO

IF COL_LENGTH('dbo.Packages', 'PTSessionCount') IS NULL
BEGIN
    ALTER TABLE dbo.Packages
    ADD PTSessionCount INT NULL;
END
GO

IF COL_LENGTH('dbo.Packages', 'Status') IS NULL
BEGIN
    ALTER TABLE dbo.Packages
    ADD Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Packages_Status DEFAULT 'Active';
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = 'FK_Packages_Trainers'
)
BEGIN
    ALTER TABLE dbo.Packages
    ADD CONSTRAINT FK_Packages_Trainers
    FOREIGN KEY (TrainerId) REFERENCES dbo.Trainers(TrainerId);
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Packages_PackageType'
)
BEGIN
    ALTER TABLE dbo.Packages
    ADD CONSTRAINT CHK_Packages_PackageType
    CHECK (PackageType IN ('NORMAL', 'PT'));
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Packages_Status'
)
BEGIN
    ALTER TABLE dbo.Packages
    ADD CONSTRAINT CHK_Packages_Status
    CHECK (Status IN ('Active', 'Inactive'));
END
GO

IF EXISTS (
    SELECT 1 FROM sys.check_constraints WHERE name = 'CK__Packages__Durati'
)
BEGIN
    ALTER TABLE dbo.Packages DROP CONSTRAINT CK__Packages__Durati;
END
GO

DECLARE @ConstraintName SYSNAME;
DECLARE @Sql NVARCHAR(MAX);

SELECT TOP 1 @ConstraintName = cc.name
FROM sys.check_constraints cc
INNER JOIN sys.tables t ON cc.parent_object_id = t.object_id
WHERE t.name = 'Packages'
  AND cc.definition LIKE '%DurationType%Day%Month%Year%';

IF @ConstraintName IS NOT NULL
BEGIN
    SET @Sql = N'ALTER TABLE dbo.Packages DROP CONSTRAINT [' + REPLACE(@ConstraintName, ']', ']]') + N']';
    EXEC sp_executesql @Sql;
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.check_constraints WHERE name = 'CHK_Packages_DurationType'
)
BEGIN
    ALTER TABLE dbo.Packages
    ADD CONSTRAINT CHK_Packages_DurationType
    CHECK (DurationType IN ('Day', 'Week', 'Month', 'Year'));
END
GO

UPDATE dbo.Packages
SET PackageType = ISNULL(PackageType, 'NORMAL'),
    Status = ISNULL(Status, 'Active')
WHERE PackageType IS NULL OR Status IS NULL;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegisterMembership
    @CustomerId INT,
    @PackageId INT,
    @TrainerId INT = NULL,
    @StartDate DATE,
    @Avatar NVARCHAR(255) = NULL,
    @IdentityNumber NVARCHAR(50) = NULL,
    @CardCode NVARCHAR(50) = NULL,
    @CreatedByStaffId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @CreatedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người tạo không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE CustomerId = @CustomerId)
        BEGIN RAISERROR(N'Khách hàng không tồn tại.', 16, 1); ROLLBACK; RETURN; END
        IF EXISTS (SELECT 1 FROM dbo.Memberships WHERE CustomerId = @CustomerId AND EndDate > @StartDate AND Status IN ('Pending','Active'))
        BEGIN RAISERROR(N'Khách còn gói tập chưa hết.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @DurationValue INT,
                @DurationType NVARCHAR(20),
                @BasePrice DECIMAL(10,2),
                @FinalPrice DECIMAL(10,2),
                @EndDate DATE,
                @Increase INT = 0,
                @NewMembershipId INT,
                @PackageType NVARCHAR(20),
                @PackageTrainerId INT;

        SELECT @DurationValue = DurationValue,
               @DurationType = DurationType,
               @BasePrice = Price,
               @PackageType = PackageType,
               @PackageTrainerId = TrainerId
        FROM dbo.Packages
        WHERE PackageId = @PackageId;

        IF @BasePrice IS NULL
        BEGIN RAISERROR(N'Gói tập không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        IF @PackageType = 'PT'
            SET @TrainerId = @PackageTrainerId;
        ELSE
            SET @TrainerId = NULL;

        SET @EndDate = CASE @DurationType
            WHEN 'Day' THEN DATEADD(DAY, @DurationValue, @StartDate)
            WHEN 'Week' THEN DATEADD(WEEK, @DurationValue, @StartDate)
            WHEN 'Month' THEN DATEADD(MONTH, @DurationValue, @StartDate)
            WHEN 'Year' THEN DATEADD(YEAR, @DurationValue, @StartDate)
        END;

        IF @TrainerId IS NOT NULL
        BEGIN
            SELECT @Increase = ISNULL(tl.PricePercentIncrease, 0)
            FROM dbo.Trainers t
            JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
            WHERE t.TrainerId = @TrainerId;
        END

        SET @FinalPrice = @BasePrice * (1 + @Increase / 100.0);

        IF @CardCode IS NULL OR LTRIM(RTRIM(@CardCode)) = N''
        BEGIN
            DECLARE @Next INT;
            SELECT @Next = ISNULL(MAX(TRY_CAST(SUBSTRING(CardCode, 5, LEN(CardCode)) AS INT)), 0) + 1
            FROM dbo.MemberProfiles WITH (UPDLOCK, HOLDLOCK)
            WHERE CardCode LIKE 'CARD%';
            SET @CardCode = N'CARD' + RIGHT('0000' + CAST(@Next AS VARCHAR(10)), 4);
        END

        IF NOT EXISTS (SELECT 1 FROM dbo.MemberProfiles WHERE CustomerId = @CustomerId)
        BEGIN
            INSERT INTO dbo.MemberProfiles(CustomerId, Avatar, IdentityNumber, CardCode, JoinDate, Status)
            VALUES (@CustomerId, @Avatar, @IdentityNumber, @CardCode, @StartDate, 'Active');
        END
        ELSE
        BEGIN
            UPDATE dbo.MemberProfiles
            SET Avatar = ISNULL(@Avatar, Avatar),
                IdentityNumber = ISNULL(@IdentityNumber, IdentityNumber),
                CardCode = ISNULL(@CardCode, CardCode),
                Status = 'Active'
            WHERE CustomerId = @CustomerId;
        END

        INSERT INTO dbo.Memberships(CustomerId, PackageId, TrainerId, StartDate, EndDate, Status, Price, CreatedAt, CreatedByStaffId)
        VALUES (@CustomerId, @PackageId, @TrainerId, @StartDate, @EndDate, 'Pending', @FinalPrice, GETDATE(), @CreatedByStaffId);

        SET @NewMembershipId = SCOPE_IDENTITY();
        COMMIT;
        SELECT @NewMembershipId AS NewMembershipId;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RenewMembership
    @CustomerId INT,
    @PackageId INT,
    @TrainerId INT = NULL,
    @StartDate DATE,
    @CreatedByStaffId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE UserId = @CreatedByStaffId AND Role IN ('Staff','Admin') AND Status = 'Active')
        BEGIN RAISERROR(N'Người gia hạn không hợp lệ.', 16, 1); ROLLBACK; RETURN; END
        IF NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE CustomerId = @CustomerId)
        BEGIN RAISERROR(N'Khách hàng không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        DECLARE @DurationValue INT,
                @DurationType NVARCHAR(20),
                @BasePrice DECIMAL(10,2),
                @FinalPrice DECIMAL(10,2),
                @EndDate DATE,
                @Increase INT = 0,
                @NewMembershipId INT,
                @PackageType NVARCHAR(20),
                @PackageTrainerId INT;

        SELECT @DurationValue = DurationValue,
               @DurationType = DurationType,
               @BasePrice = Price,
               @PackageType = PackageType,
               @PackageTrainerId = TrainerId
        FROM dbo.Packages
        WHERE PackageId = @PackageId;

        IF @BasePrice IS NULL
        BEGIN RAISERROR(N'Gói tập không tồn tại.', 16, 1); ROLLBACK; RETURN; END

        IF @PackageType = 'PT'
            SET @TrainerId = @PackageTrainerId;
        ELSE
            SET @TrainerId = NULL;

        SET @EndDate = CASE @DurationType
            WHEN 'Day' THEN DATEADD(DAY, @DurationValue, @StartDate)
            WHEN 'Week' THEN DATEADD(WEEK, @DurationValue, @StartDate)
            WHEN 'Month' THEN DATEADD(MONTH, @DurationValue, @StartDate)
            WHEN 'Year' THEN DATEADD(YEAR, @DurationValue, @StartDate)
        END;

        IF @TrainerId IS NOT NULL
        BEGIN
            SELECT @Increase = ISNULL(tl.PricePercentIncrease, 0)
            FROM dbo.Trainers t
            JOIN dbo.TrainerLevels tl ON t.LevelId = tl.LevelId
            WHERE t.TrainerId = @TrainerId;
        END

        SET @FinalPrice = @BasePrice * (1 + @Increase / 100.0);

        INSERT INTO dbo.Memberships(CustomerId, PackageId, TrainerId, StartDate, EndDate, Status, Price, CreatedAt, CreatedByStaffId)
        VALUES (@CustomerId, @PackageId, @TrainerId, @StartDate, @EndDate, 'Pending', @FinalPrice, GETDATE(), @CreatedByStaffId);

        SET @NewMembershipId = SCOPE_IDENTITY();
        COMMIT;
        SELECT @NewMembershipId AS NewMembershipId;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

/* Dữ liệu mẫu */
IF NOT EXISTS (SELECT 1 FROM dbo.Packages WHERE Name = N'Gói thường 1 tháng')
BEGIN
    INSERT INTO dbo.Packages(Name, PackageType, Price, DurationValue, DurationType, Description, Status, TrainerId, PTSessionCount)
    VALUES (N'Gói thường 1 tháng', 'NORMAL', 500000, 1, 'Month', N'Gói tập gym cơ bản trong 1 tháng', 'Active', NULL, NULL);
END
GO

IF EXISTS (SELECT 1 FROM dbo.Trainers)
   AND NOT EXISTS (SELECT 1 FROM dbo.Packages WHERE PackageType = 'PT')
BEGIN
    DECLARE @FirstTrainerId INT;
    SELECT TOP 1 @FirstTrainerId = TrainerId FROM dbo.Trainers WHERE Status = 'Active' ORDER BY TrainerId;

    INSERT INTO dbo.Packages(Name, PackageType, Price, DurationValue, DurationType, Description, Status, TrainerId, PTSessionCount)
    VALUES (N'Gói PT cá nhân 12 buổi', 'PT', 2500000, 1, 'Month', N'Gói tập cá nhân cùng PT trong 12 buổi', 'Active', @FirstTrainerId, 12);
END
GO

use GymManagementFinal
go

IF COL_LENGTH('dbo.Customers', 'Email') IS NULL
    ALTER TABLE dbo.Customers ADD Email NVARCHAR(100) NULL;
GO
IF COL_LENGTH('dbo.Customers', 'DateOfBirth') IS NULL
    ALTER TABLE dbo.Customers ADD DateOfBirth DATE NULL;
GO
IF COL_LENGTH('dbo.Customers', 'Gender') IS NULL
    ALTER TABLE dbo.Customers ADD Gender NVARCHAR(10) NULL;
GO
IF COL_LENGTH('dbo.Customers', 'Note') IS NULL
    ALTER TABLE dbo.Customers ADD Note NVARCHAR(255) NULL;
GO
IF COL_LENGTH('dbo.Customers', 'UpdatedAt') IS NULL
    ALTER TABLE dbo.Customers ADD UpdatedAt DATETIME NULL;
GO

IF COL_LENGTH('dbo.MemberProfiles', 'UpdatedAt') IS NULL
    ALTER TABLE dbo.MemberProfiles ADD UpdatedAt DATETIME NULL;
GO

/* Constraint email chỉ thêm khi chưa có */
IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = 'CHK_Customers_Email'
)
BEGIN
    ALTER TABLE dbo.Customers
    ADD CONSTRAINT CHK_Customers_Email CHECK (Email IS NULL OR Email LIKE '%@%');
END
GO

/* =========================================================
   C. Nếu muốn xóa mềm hội viên đúng chuẩn admin thì nên thêm cột IsDeleted
========================================================= */
IF COL_LENGTH('dbo.Customers', 'IsDeleted') IS NULL
    ALTER TABLE dbo.Customers ADD IsDeleted BIT NOT NULL CONSTRAINT DF_Customers_IsDeleted DEFAULT 0;
GO

/* Sau khi thêm IsDeleted, nhớ sửa tất cả query danh sách thành viên:
   ... FROM Customers c
   WHERE ISNULL(c.IsDeleted, 0) = 0
*/

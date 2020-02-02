USE new_data;
GO 

--1 thêm cột sđt gia đình vào bảng nhân viên 
ALTER TABLE MONAN ADD sđtgiadinh int;
GO

--2 xóa món ăn có đơn giá lớn hơn  30000
DELETE MONAN WHERE DONGIA >30000;
GO
 
--3 sử dụng biến cục bộ trong cơ sở dữ liệu 
DECLARE @GiaReMaNgon int ;
SET @GiaReMaNgon = 30000;
SELECT *
FROM MONAN
WHERE DONGIA<30000;

--4 sử dụng biến cục bộ với giá trị dạng table 
DECLARE @khachvip_table TABLE(
		TenKhachHang nvarchar(100),
		Tuoi int,
		ThanhPho nvarchar(100),
		SĐT int	
	);

--5 sử dụng biến toàn cục


--6 sử dụng kết hợp các lệnh điều khiển (kết hợp while , if..else, begin...end)
	DECLARE @a INT =1
	DECLARE @tong INT =0
WHILE @a < 10
BEGIN 
      IF @a = 5
            BREAK
      ELSE
            SET @tong += @a
            SET @a += 1
            CONTINUE
END
PRINT @tong 

----7 sử dụng cusor ( truyền giá dựa vào mã nhóm món ăn nếu >3 thì đơn giá là 100000
--										nếu<2 thì đơn giá là 50000
--										còn lại thì đơn giá là 30000)
DECLARE MONANCursor CURSOR FOR SELECT ID_MANHOM,TENMON  FROM MONAN

OPEN MONANCursor

DECLARE @ID_MANHOM CHAR(100)
DECLARE @TENMON NVARCHAR(100)
FETCH NEXT FROM MONANCursor INTO @ID_MANHOM,@TENMON
WHILE @@FETCH_STATUS = 0
BEGIN
	IF @ID_MANHOM > 3
	BEGIN
		UPDATE MONAN SET DONGIA = 200000 WHERE TENMON = @TENMON
	END
	ELSE 
	IF @ID_MANHOM <2
	BEGIN
		UPDATE MONAN SET DONGIA = 50000 WHERE TENMON = @TENMON
	END
	ELSE
	BEGIN
		UPDATE MONAN SET DONGIA = 30000 WHERE TENMON = @TENMON
	END
    

	FETCH NEXT FROM MONANCursor INTO @ID_MANHOM,@TENMON    
END
CLOSE MONANCursor
DEALLOCATE MONANCursor

--8 tạo một hàm function 

CREATE FUNCTION do_something
(@a INT) RETURNS INT
AS
BEGIN
DECLARE @b INT 
SET @b +=@a
RETURN @b
END
	
--9 tạo hàm function để xác định trả về bảng nhân viên khi biết mã nhân viên =1
CREATE FUNCTION bang_nhanvien
(@manhanvien INT) RETURNS TABLE 
AS
RETURN
(
SELECT * FROM NHANVIEN
WHERE @manhanvien = NHANVIEN.MANHANVIEN
)
GO

SELECT * FROM bang_nhanvien(1)
--10 tạo function để xác định trả về bảng món ăn khi biết đơn giá của món đó 
CREATE FUNCTION bang_monan
(@dongia INT) RETURNS TABLE
AS
RETURN
(
SELECT * FROM MONAN
WHERE @dongia = MONAN.DONGIA
)
GO
SELECT * FROM bang_monan(50000)
--10 Tạo function trả về kiểu bảng đếm số người đặt bàn có địa chỉ tại KIÊN GIANG 
CREATE FUNCTION count_customer_with_address2 (@address varchar(200))
RETURNS TABLE
AS 
RETURN SELECT count(*) AS 'Total customers' FROM (
    SELECT DATBAN.ID_MAKHACHHANG 
    FROM DATBAN,KHACHHANG
    WHERE DATBAN.ID_MAKHACHHANG=KHACHHANG.MAKHACHHANG AND KHACHHANG.DIACHI= @address
    GROUp BY DATBAN.ID_MAKHACHHANG
    HAVING DATBAN.MADATBAN >2
) AS Temp

SELECT * FROM dbo.count_customer_with_address2 ('Kiên Giang')

--11 Tạo function loại scalar-valued 


--12 Tạo trigger để mỗi khi có người đặt bàn thì bàn ăn sẽ được cập nhật 
CREATE TRIGGER TG_InsertNhanVien  ON dbo.NHANVIEN 
FOR INSERT

AS 
BEGIN
	--ROLLBACK TRAN
	PRINT 'TRIGGER'
END


SET IDENTITY_INSERT dbo.NHANVIEN ON;  
INSERT DBO.NHANVIEN
(
TENNHANVIEN,
MANHANVIEN,
DIACHI,
SDT
)
VALUES
(
'Nhan Vien Moi' ,
30,
'Hà Nội',
012345678
)

 --12 không cho phép xóa thông tin của khách hàng  có địa chỉ ở Hà Nội 
CREATE TRIGGER TG_KhachHangHaNoi 
  ON dbo.KHACHHANG
  FOR DELETE
  AS
  BEGIN
	DECLARE @Count INT = 0

	SELECT @Count = COUNT(*) FROM deleted
	WHERE DIACHI LIKE 'Hà Nội'

	IF(@Count>0)
	BEGIN
	PRINT N'KHÔNG ĐƯỢC XÓA KHÁCH HÀNG TIỀM NĂNG '
		ROLLBACK TRAN
		END
	END

	
	
	SELECT* FROM dbo.KHACHHANG
	delete dbo.KHACHHANG WHERE MAKHACHHANG = '12'


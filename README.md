# Kết quả Sapo Backend Home Test

## Yêu cầu
- Viết API cho phép chỉnh sửa cấu hình tích điểm lưu trữ vào database.   
- Giả sử hệ thống tại 1 thời điểm phải xử lý rất nhiều giao dịch tại 1 thời điểm (giao dịch được phát sinh liên tục), hãy viết API để ghi nhận lại các giao dịch, đồng thời xử lý tích điểm cho khách hàng, thay đổi thông tin hạng thẻ của khách hàng tương ứng.

- Viết unit test với tập dữ liệu mô tả trong file excel (data.xlsx).
- Tuỳ chọn trả lời một số câu hỏi bổ sung sau:
    - Nếu giao dịch được tổng hợp từ các hệ thống khác và định kỳ được tải lên hệ thống tích điểm, thì xử lý như thế nào trong trường hợp cấu hình quy đổi điểm bị thay đổi giữa các lần giao dịch của khách hàng.    
    VD: Khách hàng có 3 giao dịch mua hàng vào buổi sáng, và 2 giao dịch vào buổi chiều cùng ngày. Cấu hình quy đổi điểm được thay đổi vào 12h trưa ngày hôm đó. 22h cuối ngày thì dữ liệu mới được tổng hợp về hệ thống tích điểm.

## Lưu ý
- Do chưa cài SSMS nên hiện đang dùng tạm file json thay cho database.
- Một số PostAPI đang sử dụng dưới dạng GetAPI có truyền data để dễ test.
- Yêu cầu 1: 
API dạng: /ratioconfig/{value}  (GET)
trong đó value là giá trị cấu hình tích điểm, default là 0;
- Yêu cầu 2: 
Ý tưởng: Lưu toàn bộ giao dịch vào database với flag đang đợi
Sử dụng service hoặc Schedule để chạy liên tục 1 API khác để xử lý các giao dịch đã được lưu trong database và cập nhật lại kêt quả

API lưu giao dịch dạng: /transaction (POST) data truyền vào từ body
API xử lý giao dịch dạng: /transactionProcess/Process (GET)

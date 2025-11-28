using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebsiteKhoaHoc.Models;

namespace WebsiteKhoaHoc.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Kiểm tra xem đã có dữ liệu chưa
            if (context.Courses.Any())
            {
                return; // Đã có dữ liệu
            }

            // Tạo 20 user mẫu
            var users = new List<ApplicationUser>();
            
            for (int i = 1; i <= 20; i++)
            {
                var email = $"user{i}@example.com";
                var existingUser = await userManager.FindByEmailAsync(email);
                
                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FullName = $"Nguyễn Văn {(char)(64 + i)}",
                        EmailConfirmed = true,
                        IsActive = true,
                        CreatedAt = DateTime.Now.AddDays(-60 + i * 2)
                    };

                    await userManager.CreateAsync(user, "User@123");
                    await userManager.AddToRoleAsync(user, "User");
                    users.Add(user);
                }
            }

            // Tạo 25 khóa học mẫu với nội dung chi tiết
            var courses = new List<Course>
            {
                // Lập trình (10 khóa)
                new Course
                {
                    Title = "Lập trình ASP.NET Core MVC từ A-Z",
                    Description = "Khóa học toàn diện về ASP.NET Core MVC, từ cơ bản đến nâng cao. Bạn sẽ học cách xây dựng ứng dụng web hoàn chỉnh với Entity Framework, Identity, và nhiều tính năng khác. Khóa học bao gồm: MVC Pattern, Routing, Controllers, Views, Models, Entity Framework Core, Authentication & Authorization, RESTful APIs, Deployment.",
                    Price = 1999000,
                    CategoryId = 1,
                    InstructorName = "Nguyễn Văn An",
                    InstructorBio = "10 năm kinh nghiệm phát triển web với .NET, Microsoft MVP, Senior Software Engineer tại FPT Software",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-45),
                    CoverImage = "/images/courses/aspnet-core.jpg"
                },
                new Course
                {
                    Title = "React JS - Xây dựng ứng dụng Single Page",
                    Description = "Học React JS từ cơ bản đến nâng cao. Xây dựng các ứng dụng web hiện đại với React Hooks, Redux, React Router. Nội dung: Components, Props & State, Lifecycle, Hooks (useState, useEffect, useContext), Redux Toolkit, React Router v6, API Integration, Performance Optimization.",
                    Price = 1499000,
                    CategoryId = 1,
                    InstructorName = "Trần Thị Bình",
                    InstructorBio = "Frontend Developer tại Shopee, 7 năm kinh nghiệm với React, Angular, Vue.js",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-42),
                    CoverImage = "/images/courses/react-js.jpg"
                },
                new Course
                {
                    Title = "Python cho Data Science & Machine Learning",
                    Description = "Khóa học Python chuyên sâu cho Data Science, bao gồm NumPy, Pandas, Matplotlib, Seaborn, Scikit-learn và Machine Learning cơ bản. Học cách xử lý dữ liệu, phân tích, visualize và xây dựng mô hình ML.",
                    Price = 1799000,
                    CategoryId = 1,
                    InstructorName = "Đỗ Văn Đức",
                    InstructorBio = "Data Scientist tại VinAI, PhD in Computer Science, chuyên gia AI/ML",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-40),
                    CoverImage = "/images/courses/python-data-science.jpg"
                },
                new Course
                {
                    Title = "Node.js & Express - Backend Development",
                    Description = "Xây dựng RESTful API với Node.js và Express. Học MongoDB, JWT Authentication, File Upload, Email Service, Payment Integration. Khóa học thực tế với nhiều dự án thực chiến.",
                    Price = 1599000,
                    CategoryId = 1,
                    InstructorName = "Lê Minh Tuấn",
                    InstructorBio = "Backend Developer, 8 năm kinh nghiệm với Node.js, Go, Java",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-38),
                    CoverImage = "/images/courses/nodejs-express.jpg"
                },
                new Course
                {
                    Title = "Flutter - Xây dựng Mobile App đa nền tảng",
                    Description = "Học Flutter để xây dựng ứng dụng mobile cho iOS và Android. Dart programming, Widgets, State Management (Provider, Riverpod), Firebase Integration, REST API, Local Storage.",
                    Price = 1899000,
                    CategoryId = 1,
                    InstructorName = "Phạm Thị Hương",
                    InstructorBio = "Mobile Developer, Google Developer Expert, tác giả nhiều app trên App Store và Play Store",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-36),
                    CoverImage = "/images/courses/flutter.jpg"
                },
                new Course
                {
                    Title = "Java Spring Boot - Enterprise Application",
                    Description = "Xây dựng ứng dụng doanh nghiệp với Spring Boot. Spring MVC, Spring Data JPA, Spring Security, Microservices, Docker, Kubernetes. Khóa học cho developer muốn làm việc với hệ thống lớn.",
                    Price = 2199000,
                    CategoryId = 1,
                    InstructorName = "Hoàng Văn Nam",
                    InstructorBio = "Senior Java Developer, 12 năm kinh nghiệm, Certified Spring Professional",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-34),
                    CoverImage = "/images/courses/spring-boot.jpg"
                },
                new Course
                {
                    Title = "Vue.js 3 - Progressive JavaScript Framework",
                    Description = "Học Vue.js 3 với Composition API, Pinia State Management, Vue Router, Vite. Xây dựng SPA hiện đại với performance cao. Bao gồm TypeScript integration và best practices.",
                    Price = 1399000,
                    CategoryId = 1,
                    InstructorName = "Nguyễn Thị Mai",
                    InstructorBio = "Frontend Architect, Vue.js core contributor, 9 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-32),
                    CoverImage = "/images/courses/vuejs.jpg"
                },
                new Course
                {
                    Title = "SQL Server & Database Design",
                    Description = "Thiết kế database chuyên nghiệp, T-SQL, Stored Procedures, Functions, Triggers, Indexing, Query Optimization, Backup & Recovery. Khóa học cho Database Administrator và Backend Developer.",
                    Price = 1299000,
                    CategoryId = 1,
                    InstructorName = "Trần Văn Hải",
                    InstructorBio = "Database Administrator, Microsoft Certified, 15 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    CoverImage = "/images/courses/sql-server.jpg"
                },
                new Course
                {
                    Title = "DevOps - CI/CD với Docker & Kubernetes",
                    Description = "Học DevOps từ cơ bản đến nâng cao. Docker, Docker Compose, Kubernetes, Jenkins, GitLab CI/CD, Monitoring với Prometheus & Grafana. Automation và Infrastructure as Code.",
                    Price = 2299000,
                    CategoryId = 1,
                    InstructorName = "Lê Văn Phong",
                    InstructorBio = "DevOps Engineer, AWS Certified, Kubernetes Administrator",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-28),
                    CoverImage = "/images/courses/devops.jpg"
                },
                new Course
                {
                    Title = "Angular - Enterprise Web Development",
                    Description = "Xây dựng ứng dụng web doanh nghiệp với Angular. TypeScript, Components, Services, RxJS, NgRx State Management, Angular Material, Testing với Jasmine & Karma.",
                    Price = 1699000,
                    CategoryId = 1,
                    InstructorName = "Đặng Thị Lan",
                    InstructorBio = "Senior Frontend Developer, Angular expert, 10 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-26),
                    CoverImage = "/images/courses/angular.jpg"
                },

                // Marketing (5 khóa)
                new Course
                {
                    Title = "Digital Marketing toàn diện từ A-Z",
                    Description = "Khóa học marketing số toàn diện, bao gồm SEO, SEM, Social Media Marketing, Email Marketing, Content Marketing, Analytics. Chiến lược marketing hiệu quả cho doanh nghiệp.",
                    Price = 999000,
                    CategoryId = 2,
                    InstructorName = "Lê Minh Cường",
                    InstructorBio = "Digital Marketing Manager với 8 năm kinh nghiệm, Google Ads Certified",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-24),
                    CoverImage = "/images/courses/digital-marketing.jpg"
                },
                new Course
                {
                    Title = "Facebook Ads Mastery - Quảng cáo Facebook chuyên sâu",
                    Description = "Làm chủ quảng cáo Facebook từ A-Z. Tối ưu chi phí, tăng conversion, scale chiến dịch hiệu quả. Facebook Pixel, Custom Audience, Lookalike, A/B Testing, Analytics.",
                    Price = 1199000,
                    CategoryId = 2,
                    InstructorName = "Nguyễn Thị Mai",
                    InstructorBio = "Facebook Ads Expert, quản lý ngân sách 10+ tỷ/năm, Meta Blueprint Certified",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-22),
                    CoverImage = "/images/courses/facebook-ads.jpg"
                },
                new Course
                {
                    Title = "Google Ads & SEO - Chinh phục trang đầu Google",
                    Description = "Học Google Ads và SEO để đưa website lên top Google. Keyword Research, On-page SEO, Off-page SEO, Technical SEO, Google Ads Campaign, Quality Score Optimization.",
                    Price = 1299000,
                    CategoryId = 2,
                    InstructorName = "Phạm Văn Đức",
                    InstructorBio = "SEO Specialist, Google Ads Expert, 10 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    CoverImage = "/images/courses/google-ads-seo.jpg"
                },
                new Course
                {
                    Title = "Content Marketing & Copywriting",
                    Description = "Viết content thu hút, chuyển đổi cao. Storytelling, SEO Writing, Email Copywriting, Sales Copy, Landing Page Optimization. Học cách viết content viral trên social media.",
                    Price = 899000,
                    CategoryId = 2,
                    InstructorName = "Trần Thị Hương",
                    InstructorBio = "Content Strategist, Copywriter cho các thương hiệu lớn",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-18),
                    CoverImage = "/images/courses/content-marketing.jpg"
                },
                new Course
                {
                    Title = "TikTok Marketing - Viral Marketing trên TikTok",
                    Description = "Chiến lược marketing trên TikTok. Tạo content viral, TikTok Ads, Influencer Marketing, TikTok Shop, Analytics. Học cách tận dụng TikTok để bán hàng hiệu quả.",
                    Price = 799000,
                    CategoryId = 2,
                    InstructorName = "Lê Thị Ngọc",
                    InstructorBio = "TikTok Marketing Expert, quản lý nhiều tài khoản triệu followers",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-16),
                    CoverImage = "/images/courses/tiktok-marketing.jpg"
                },

                // Thiết kế (5 khóa)
                new Course
                {
                    Title = "UI/UX Design với Figma - Từ cơ bản đến chuyên nghiệp",
                    Description = "Học thiết kế giao diện người dùng chuyên nghiệp với Figma. Từ wireframe đến prototype hoàn chỉnh. Design System, Component Library, Auto Layout, Plugins.",
                    Price = 1299000,
                    CategoryId = 3,
                    InstructorName = "Phạm Thu Hà",
                    InstructorBio = "Senior UI/UX Designer, đã thiết kế cho 100+ dự án, Figma Community Leader",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-14),
                    CoverImage = "/images/courses/ui-ux-figma.jpg"
                },
                new Course
                {
                    Title = "Adobe Photoshop - Thiết kế đồ họa chuyên nghiệp",
                    Description = "Làm chủ Photoshop cho thiết kế đồ họa. Photo Editing, Retouching, Compositing, Typography, Banner Design, Social Media Graphics. Từ cơ bản đến nâng cao.",
                    Price = 1099000,
                    CategoryId = 3,
                    InstructorName = "Nguyễn Văn Tùng",
                    InstructorBio = "Graphic Designer, Adobe Certified Expert, 12 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-12),
                    CoverImage = "/images/courses/photoshop.jpg"
                },
                new Course
                {
                    Title = "Adobe Illustrator - Vector Graphics Design",
                    Description = "Thiết kế vector chuyên nghiệp với Illustrator. Logo Design, Icon Design, Illustration, Typography, Packaging Design. Kỹ thuật và tips từ chuyên gia.",
                    Price = 1099000,
                    CategoryId = 3,
                    InstructorName = "Trần Thị Linh",
                    InstructorBio = "Illustrator, Logo Designer cho các thương hiệu quốc tế",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    CoverImage = "/images/courses/illustrator.jpg"
                },
                new Course
                {
                    Title = "Motion Graphics với After Effects",
                    Description = "Tạo hiệu ứng chuyển động chuyên nghiệp. Animation, Visual Effects, Typography Animation, Logo Animation, Explainer Videos. Từ cơ bản đến nâng cao.",
                    Price = 1499000,
                    CategoryId = 3,
                    InstructorName = "Lê Văn Hùng",
                    InstructorBio = "Motion Designer, làm việc cho các agency lớn, 8 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-8),
                    CoverImage = "/images/courses/after-effects.jpg"
                },
                new Course
                {
                    Title = "Blender 3D - Modeling & Animation",
                    Description = "Học 3D modeling và animation với Blender. Character Modeling, Product Visualization, Architectural Visualization, Animation, Rendering với Cycles và Eevee.",
                    Price = 1699000,
                    CategoryId = 3,
                    InstructorName = "Đỗ Văn Long",
                    InstructorBio = "3D Artist, Blender Foundation Certified Trainer",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-6),
                    CoverImage = "/images/courses/blender.jpg"
                },

                // Kinh doanh (3 khóa)
                new Course
                {
                    Title = "Quản trị Kinh doanh Hiện đại",
                    Description = "Khóa học về quản trị doanh nghiệp, chiến lược kinh doanh, quản lý nhân sự và tài chính. Business Model Canvas, OKR, KPI, Financial Planning, Leadership.",
                    Price = 2499000,
                    CategoryId = 4,
                    InstructorName = "Hoàng Minh Tuấn",
                    InstructorBio = "MBA, CEO của startup công nghệ, mentor cho 50+ startups",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-4),
                    CoverImage = "/images/courses/business-management.jpg"
                },
                new Course
                {
                    Title = "Khởi nghiệp & Xây dựng Startup",
                    Description = "Hướng dẫn khởi nghiệp từ A-Z. Tìm ý tưởng, validate, xây dựng MVP, fundraising, scaling. Kinh nghiệm thực tế từ founder thành công.",
                    Price = 1999000,
                    CategoryId = 4,
                    InstructorName = "Nguyễn Văn Khoa",
                    InstructorBio = "Serial Entrepreneur, đã exit 2 startups, Angel Investor",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-3),
                    CoverImage = "/images/courses/startup.jpg"
                },
                new Course
                {
                    Title = "Kỹ năng Bán hàng & Đàm phán",
                    Description = "Nâng cao kỹ năng bán hàng và đàm phán. Sales Funnel, Closing Techniques, Negotiation Skills, Customer Psychology, CRM. Tăng doanh số hiệu quả.",
                    Price = 1299000,
                    CategoryId = 4,
                    InstructorName = "Trần Văn Thành",
                    InstructorBio = "Sales Director, Top 1% Sales Performer, 15 năm kinh nghiệm",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    CoverImage = "/images/courses/sales-skills.jpg"
                },

                // Ngoại ngữ (2 khóa)
                new Course
                {
                    Title = "Tiếng Anh Giao tiếp Thực tế",
                    Description = "Học tiếng Anh giao tiếp thực tế cho công việc và cuộc sống hàng ngày. Phương pháp học hiệu quả, luyện phát âm chuẩn, giao tiếp tự tin.",
                    Price = 799000,
                    CategoryId = 5,
                    InstructorName = "Sarah Johnson",
                    InstructorBio = "Giáo viên bản ngữ với 15 năm kinh nghiệm, TESOL Certified",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    CoverImage = "/images/courses/english-speaking.jpg"
                },
                new Course
                {
                    Title = "IELTS 7.0+ - Chinh phục IELTS",
                    Description = "Lộ trình học IELTS đạt 7.0+. Chiến lược làm bài cho cả 4 kỹ năng: Listening, Reading, Writing, Speaking. Tài liệu độc quyền và tips từ giáo viên 8.5 IELTS.",
                    Price = 1499000,
                    CategoryId = 5,
                    InstructorName = "Nguyễn Thị Hoa",
                    InstructorBio = "IELTS 8.5, giảng viên IELTS 10 năm, đã giúp 1000+ học viên đạt 7.0+",
                    Status = CourseStatus.Published,
                    CreatedAt = DateTime.Now,
                    CoverImage = "/images/courses/ielts.jpg"
                }
            };

            context.Courses.AddRange(courses);
            await context.SaveChangesAsync();

            // Tạo bài học cho mỗi khóa học (15 bài/khóa)
            var lessons = new List<Lesson>();
            var lessonTitles = new[]
            {
                "Giới thiệu và cài đặt môi trường",
                "Khái niệm cơ bản và nền tảng",
                "Thực hành đầu tiên - Hello World",
                "Làm việc với dữ liệu",
                "Các kỹ thuật nâng cao",
                "Best Practices và Design Patterns",
                "Xây dựng dự án thực tế - Phần 1",
                "Xây dựng dự án thực tế - Phần 2",
                "Xây dựng dự án thực tế - Phần 3",
                "Tối ưu hóa và Performance",
                "Testing và Quality Assurance",
                "Security và Best Practices",
                "Debugging và Troubleshooting",
                "Deployment và Production",
                "Tổng kết và Next Steps"
            };

            foreach (var course in courses)
            {
                for (int i = 0; i < 15; i++)
                {
                    lessons.Add(new Lesson
                    {
                        CourseId = course.Id,
                        Title = $"Bài {i + 1}: {lessonTitles[i]}",
                        Description = $"Nội dung chi tiết của {lessonTitles[i]}. Trong bài học này, bạn sẽ được học về các khái niệm quan trọng và thực hành với các ví dụ thực tế.",
                        VideoUrl = $"https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                        OrderIndex = i + 1,
                        DurationMinutes = 20 + (i * 5),
                        CreatedAt = DateTime.Now.AddDays(-50 + i)
                    });
                }
            }

            context.Lessons.AddRange(lessons);
            await context.SaveChangesAsync();

            // Tạo nhiều đơn hàng mẫu (50 đơn)
            if (users.Any())
            {
                var orders = new List<Order>();
                var random = new Random();

                for (int i = 0; i < 50; i++)
                {
                    var user = users[random.Next(users.Count)];
                    var course = courses[random.Next(courses.Count)];

                    // Tránh trùng lặp user-course
                    if (!orders.Any(o => o.UserId == user.Id && o.CourseId == course.Id))
                    {
                        orders.Add(new Order
                        {
                            UserId = user.Id,
                            CourseId = course.Id,
                            Amount = course.Price,
                            PaymentStatus = PaymentStatus.Completed,
                            PaymentMethod = random.Next(3) switch
                            {
                                0 => "Demo",
                                1 => "VNPay",
                                _ => "MoMo"
                            },
                            TransactionId = Guid.NewGuid().ToString(),
                            CreatedAt = DateTime.Now.AddDays(-random.Next(1, 60)),
                            CompletedAt = DateTime.Now.AddDays(-random.Next(1, 60))
                        });
                    }
                }

                context.Orders.AddRange(orders);
                await context.SaveChangesAsync();

                // Tạo tiến độ học tập
                var progresses = new List<CourseProgress>();
                foreach (var order in orders)
                {
                    var courseLessons = lessons.Where(l => l.CourseId == order.CourseId).ToList();
                    var completed = random.Next(0, courseLessons.Count + 1);

                    progresses.Add(new CourseProgress
                    {
                        UserId = order.UserId,
                        CourseId = order.CourseId,
                        LastLessonId = courseLessons.Skip(Math.Min(completed, courseLessons.Count - 1)).FirstOrDefault()?.Id,
                        CompletedLessons = completed,
                        TotalLessons = courseLessons.Count,
                        LastAccessedAt = DateTime.Now.AddDays(-random.Next(1, 14))
                    });
                }

                context.CourseProgresses.AddRange(progresses);
                await context.SaveChangesAsync();

                // Tạo nhiều đánh giá (60 đánh giá)
                var reviews = new List<Review>();
                var reviewComments = new[]
                {
                    "Khóa học rất hay và bổ ích! Giảng viên giải thích rất dễ hiểu, tôi đã học được rất nhiều.",
                    "Nội dung chất lượng, đáng đồng tiền bát gạo. Recommend cho mọi người!",
                    "Học được rất nhiều kiến thức thực tế. Cảm ơn giảng viên đã chia sẻ!",
                    "Khóa học tốt, nhưng có thể thêm nhiều ví dụ thực tế hơn nữa.",
                    "Tuyệt vời! Đây là khóa học tốt nhất tôi từng tham gia. 5 sao không thể thiếu!",
                    "Giảng viên nhiệt tình, nội dung cập nhật. Rất hài lòng với khóa học này!",
                    "Khóa học phù hợp cho người mới bắt đầu. Dễ hiểu và có hệ thống rõ ràng.",
                    "Chất lượng video tốt, âm thanh rõ ràng. Nội dung hay và dễ theo dõi!",
                    "Học xong áp dụng được ngay vào công việc. Rất thực tế và hữu ích!",
                    "Giá hơi cao nhưng hoàn toàn xứng đáng với chất lượng khóa học.",
                    "Nội dung đầy đủ, chi tiết. Giảng viên giải thích từng bước một rất kỹ.",
                    "Tôi đã thử nhiều khóa học khác nhưng khóa này là tốt nhất!",
                    "Rất đáng để đầu tư. Kiến thức cập nhật và thực tế.",
                    "Giảng viên có kinh nghiệm thực tế, chia sẻ nhiều case study hay.",
                    "Khóa học giúp tôi tự tin hơn trong công việc. Cảm ơn rất nhiều!",
                    "Video dễ hiểu, có subtitle tiếng Việt rất tốt.",
                    "Tài liệu đi kèm rất hữu ích. Có thể download về học lại nhiều lần.",
                    "Support tốt, giảng viên trả lời câu hỏi nhanh chóng.",
                    "Khóa học này vượt quá mong đợi của tôi. Highly recommended!",
                    "Nội dung cập nhật theo xu hướng mới nhất. Rất đáng học!"
                };

                for (int i = 0; i < 60; i++)
                {
                    var user = users[random.Next(users.Count)];
                    var course = courses[random.Next(courses.Count)];

                    // Chỉ review nếu đã mua khóa học
                    if (orders.Any(o => o.UserId == user.Id && o.CourseId == course.Id) &&
                        !reviews.Any(r => r.UserId == user.Id && r.CourseId == course.Id))
                    {
                        var rating = random.Next(10) < 7 ? random.Next(4, 6) : random.Next(3, 4); // 70% là 4-5 sao

                        reviews.Add(new Review
                        {
                            UserId = user.Id,
                            CourseId = course.Id,
                            Rating = rating,
                            Comment = reviewComments[random.Next(reviewComments.Length)],
                            CreatedAt = DateTime.Now.AddDays(-random.Next(1, 50))
                        });
                    }
                }

                context.Reviews.AddRange(reviews);
                await context.SaveChangesAsync();
            }
        }
    }
}

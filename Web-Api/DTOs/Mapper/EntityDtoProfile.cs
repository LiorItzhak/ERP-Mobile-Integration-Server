using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Entities.Products;
using DataAccessLayer.Entities.Products.Properties;
using System;
using DataAccessLayer.Entities.Authentication;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;
using DataAccessLayer.Entities.Documents.Utils;
using DataAccessLayer.Entities.UserData;
using LogicLib.Services;
using Web_Api.Controllers.Docs.Utils;
using Web_Api.DTOs.Authentication;
using Web_Api.DTOs.Documents;
using Web_Api.DTOs.Products;
using static Web_Api.DTOs.Documents.DocItemDto;
using Activity = DataAccessLayer.Entities.BusinessPartners.Activity;
using GeoLocation = DataAccessLayer.Entities.GeoLocation;

namespace Web_Api.DTOs.Mapper
{
    /// <summary>
    /// http://docs.automapper.org/en/stable/
    /// </summary>
    public class EntityDtoProfile : Profile
    {
        public EntityDtoProfile()
        {
            CreateMap<DateTime, string>()
                .ConvertUsing(s => s.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffff")); //ISO 8601  2008-06-15T21:15:07.3921336
            CreateMap<string, DateTime>()
                .ConvertUsing(s => DateTime.Parse(s));
            
            CreateMap<DateTime?, string>()
                .ConvertUsing(s => s.HasValue ? s.Value.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffff") : null); //ISO 8601  2008-06-15T21:15:07.3921336
            CreateMap<string, DateTime?>()
                .ConvertUsing(s => s != null ? DateTime.Parse(s) : new DateTime?());
            
            
            CreateMap<DateTimeOffset, string>()
                .ConvertUsing(s => s.ToString("o")); //ISO 8601 2008-06-15T21:15:07.0000000+03:00
            CreateMap<string, DateTimeOffset>()
                .ConvertUsing(s => DateTimeOffset.Parse(s));
            CreateMap<DateTimeOffset?, string>()
                .ConvertUsing(s => s.HasValue ? s.Value.ToString("o") : null); //ISO 8601  2008-06-15T21:15:07.3921336+03:00
            CreateMap<string, DateTimeOffset?>()
                .ConvertUsing(s => s != null ? DateTimeOffset.Parse(s) : new DateTimeOffset?());
            
            

            CreateMap<CardGroup, CardGroupDto>().ReverseMap();
            CreateMap<Indicator, IndicatorDto>().ReverseMap();
            CreateMap<Industry, IndustryDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CompanyEntity, CompanyDto>().ReverseMap();
            CreateMap<BankEntity, BankDto>().ReverseMap();
            CreateMap<BankAccountEntity, BankAccountDto>().ReverseMap();
            CreateMap<GeoLocation, GeoLocationDto>().ReverseMap();

            CreateMap<UserData, UserDataDto>()
                .ForMember(dest => dest.BusinessPartnerCode, opt => opt.MapFrom(src => src.LeadSn))
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModifiedUtc))

                .ReverseMap()
                .ForPath(dest => dest.LeadSn, opt => opt.MapFrom(src => src.BusinessPartnerCode))
                .ForPath(dest => dest.LastModifiedUtc, opt => opt.MapFrom(src => src.LastModified));

            CreateMap<BusinessPartner, BusinessPartnerDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                    src.Type == BusinessPartner.CardType.Company ? BusinessPartnerDto.CardType.Company :
                    src.Type == BusinessPartner.CardType.Employee ? BusinessPartnerDto.CardType.Employee :
                    BusinessPartnerDto.CardType.Private))
                .ForMember(dest => dest.PartnerType, opt => opt.MapFrom(src =>
                    src.PartnerType == BusinessPartner.PartnerTypes.Customer
                        ? BusinessPartnerDto.PartnerTypes.Customer
                        : src.PartnerType == BusinessPartner.PartnerTypes.Lead
                            ? BusinessPartnerDto.PartnerTypes.Lead
                            : BusinessPartnerDto.PartnerTypes.Supplier))
//                .ForMember(dest => dest.GeoLocation,
//                    opt => opt.MapFrom(src =>
//                        (src.GeoLocation != null && src.GeoLocation.HasLocation()) ? src.GeoLocation : null))
                .ReverseMap()
                .ForMember(x => x.PartnerType, opt => opt.MapFrom(x => BusinessPartner.PartnerTypes.Customer))
                .ForPath(dest => dest.Type, opt => opt.MapFrom(src =>
                    src.Type == BusinessPartnerDto.CardType.Company ? BusinessPartner.CardType.Company :
                    src.Type == BusinessPartnerDto.CardType.Employee ? BusinessPartner.CardType.Employee :
                    BusinessPartner.CardType.Private))
                .ForMember(dest => dest.PartnerType, opt => opt.MapFrom(src =>
                    src.PartnerType == BusinessPartnerDto.PartnerTypes.Customer
                        ? BusinessPartner.PartnerTypes.Customer
                        : src.PartnerType == BusinessPartnerDto.PartnerTypes.Lead
                            ? BusinessPartner.PartnerTypes.Lead
                            : BusinessPartner.PartnerTypes.Supplier));


            CreateMap<AccountBalanceRecordEntity, AccountBalanceRecordDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(entity =>
                    entity.Type == AccountBalanceRecordEntity.DocumentTypes.Invoice
                        ? AccountBalanceRecordEntity.DocumentTypes.Invoice
                        : entity.Type == AccountBalanceRecordEntity.DocumentTypes.Receipt
                            ? AccountBalanceRecordEntity.DocumentTypes.Receipt
                            : entity.Type == AccountBalanceRecordEntity.DocumentTypes.CreditInvoice
                                ? AccountBalanceRecordEntity.DocumentTypes.CreditInvoice
                                : entity.Type == AccountBalanceRecordEntity.DocumentTypes.Journal
                                    ? AccountBalanceRecordEntity.DocumentTypes.Journal
                                    : AccountBalanceRecordEntity.DocumentTypes.Other))
                .ReverseMap()
                .ForPath(dest => dest.Type, opt => opt.MapFrom(dto =>
                    dto.Type == AccountBalanceRecordDto.DocumentTypes.Invoice
                        ? AccountBalanceRecordEntity.DocumentTypes.Invoice
                        : dto.Type == AccountBalanceRecordDto.DocumentTypes.Receipt
                            ? AccountBalanceRecordEntity.DocumentTypes.Receipt
                            : dto.Type == AccountBalanceRecordDto.DocumentTypes.CreditInvoice
                                ? AccountBalanceRecordEntity.DocumentTypes.CreditInvoice
                                : dto.Type == AccountBalanceRecordDto.DocumentTypes.Journal
                                    ? AccountBalanceRecordEntity.DocumentTypes.Journal
                                    : AccountBalanceRecordEntity.DocumentTypes.Other));


            CreateMap<SalesmanEntity, SalesmanDto>()
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(entity => entity.ActiveStatus == SalesmanEntity.Status.Active))
                .ReverseMap()
                .ForMember(dest => dest.ActiveStatus,
                    opt => opt.MapFrom(dto =>
                        dto.IsActive ? SalesmanEntity.Status.Active : SalesmanEntity.Status.NoActive));


            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<JobPosition, JobPositionDto>().ReverseMap();

            CreateMap<EmployeeEntity, EmployeeDto>()
                .ForMember(dest => dest.Gender,
                    opt => opt.MapFrom(src =>
                        src.Gender == EmployeeEntity.GenderTypes.Male
                            ? EmployeeEntity.GenderTypes.Male
                            : EmployeeEntity.GenderTypes.Female))
                .ReverseMap()
                .ForPath(dest => dest.Gender,
                    opt => opt.MapFrom(src =>
                        src.Gender == EmployeeDto.GenderTypes.Male
                            ? EmployeeEntity.GenderTypes.Male
                            : EmployeeEntity.GenderTypes.Female));


            CreateMap<ProductGroupEntity, ProductGroupDto>().ReverseMap();
            CreateMap<ProductEntity, ProductDto>().ReverseMap();

            //Documents
            CreateMap<DocItemEntity, DocItemDto>().ReverseMap();
            CreateMap<DocReferencedEntity, DocReferenceDto>().ReverseMap();


            CreateMap<QuotationEntity, QuotationDto>().ReverseMap();
            CreateMap<QuotationHeaderEntity, QuotationDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<DeliveryNoteEntity, DeliveryNoteDto>().ReverseMap();
            CreateMap<DeliveryNoteHeaderEntity, DeliveryNoteDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<CreditNoteEntity, CreditNoteDto>().ReverseMap();
            CreateMap<CreditNoteHeaderEntity, CreditNoteDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<InvoiceEntity, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceHeaderEntity, InvoiceDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<OrderEntity, OrderDto>().ReverseMap();
            CreateMap<OrderHeaderEntity, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<DownPaymentRequest, DownPaymentRequestDto>().ReverseMap();
            CreateMap<DownPaymentRequestHeader, DownPaymentRequestDto>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<DocumentsSummery, DocumentsSummeryDto>().ReverseMap();

            CreateMap<UserRegistrationRequest, UserRegistrationRequestDto>().ReverseMap();

            CreateMap<IdentityUser, UserDto>()
                .ForMember(x => x.EmpSn, opt => opt.MapFrom(entity => entity.EmpId))
                .ReverseMap()
                .ForPath(dest => dest.EmpId, opt => opt.MapFrom(dto => dto.EmpSn));


            CreateMap<ProductPropertyEntity, ProductPropertyDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(entity =>
                    entity.Type == ProductPropertyEntity.PropertyType.Choice
                        ? ProductPropertyDto.PropertyType.Choice
                        :
                        entity.Type == ProductPropertyEntity.PropertyType.Date
                            ? ProductPropertyDto.PropertyType.Date
                            :
                            entity.Type == ProductPropertyEntity.PropertyType.Int
                                ? ProductPropertyDto.PropertyType.Int
                                :
                                entity.Type == ProductPropertyEntity.PropertyType.Decimal
                                    ?
                                    ProductPropertyDto.PropertyType.Decimal
                                    :
                                    ProductPropertyDto.PropertyType.Text
                ))
                .ReverseMap()
                .ForPath(dest => dest.Type, opt => opt.MapFrom(dto =>
                    dto.Type == ProductPropertyDto.PropertyType.Choice ? ProductPropertyEntity.PropertyType.Choice :
                    dto.Type == ProductPropertyDto.PropertyType.Date ? ProductPropertyEntity.PropertyType.Date :
                    dto.Type == ProductPropertyDto.PropertyType.Int ? ProductPropertyEntity.PropertyType.Int :
                    dto.Type == ProductPropertyDto.PropertyType.Decimal ? ProductPropertyEntity.PropertyType.Decimal :
                    ProductPropertyEntity.PropertyType.Text
                ));

            CreateMap<UserLocation, UserLocationDto>()
                .ReverseMap()
                .ForMember(dest => dest.Key, opt => opt.Ignore())
                .ForMember(dest => dest.DeviceId, opt => opt.Ignore());

            CreateMap<SetUserForm, SetUserFormDto>().ReverseMap();


            CreateMap<UserDto.UserRole, IdentityUser.UserRole>()
                .ConvertUsing(s =>
                    // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                    s == UserDto.UserRole.Admin ? IdentityUser.UserRole.Admin :
                    s == UserDto.UserRole.Manager ? IdentityUser.UserRole.Manager :
                    IdentityUser.UserRole.Standard
                );

            CreateMap<UserDto.UserRole?, IdentityUser.UserRole?>()
                .ConvertUsing(s =>
                    s.HasValue == false ? new IdentityUser.UserRole?() :
                    s == UserDto.UserRole.Admin ? IdentityUser.UserRole.Admin :
                    s == UserDto.UserRole.Manager ? IdentityUser.UserRole.Manager :
                    IdentityUser.UserRole.Standard);


            CreateMap<EmployeeTimeClock, EmployeeTimeClockDto>().ReverseMap();
            CreateMap<CheckInRequestDto, CheckInRequest>();
            CreateMap<CheckOutRequestDto, CheckOutRequest>();
            CreateMap<AuthenticationResult, AuthenticationResultDto>();


            CreateMap<ActivityDto, Activity>()
                .ForMember(dest => dest.Action, opt => opt.MapFrom(entity =>
                    // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                    entity.Action == ActivityDto.ActionType.PhoneCall ? Activity.ActionType.PhoneCall :
                    entity.Action == ActivityDto.ActionType.Meeting ? Activity.ActionType.Meeting :
                    entity.Action == ActivityDto.ActionType.Task ? Activity.ActionType.Task :
                    entity.Action == ActivityDto.ActionType.Note ? Activity.ActionType.Note :
                    entity.Action == ActivityDto.ActionType.Campaign ? Activity.ActionType.Campaign :
                    Activity.ActionType.Other
                ))
                .ReverseMap()
                .ForPath(dest => dest.Action, opt => opt.MapFrom(dto =>

                    // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                    dto.Action == Activity.ActionType.PhoneCall ? ActivityDto.ActionType.PhoneCall :
                    dto.Action == Activity.ActionType.Meeting ? ActivityDto.ActionType.Meeting :
                    dto.Action == Activity.ActionType.Task ? ActivityDto.ActionType.Task :
                    dto.Action == Activity.ActionType.Note ? ActivityDto.ActionType.Note :
                    dto.Action == Activity.ActionType.Campaign ? ActivityDto.ActionType.Campaign :
                    ActivityDto.ActionType.Other
                ));


            CreateMap<ActivityTypeDto, ActivityType>().ReverseMap();
            CreateMap<ActivitySubjectDto, ActivitySubject>().ReverseMap();


            CreateMap<AttachmentDto, Attachment>().ReverseMap();
        }
    }
}
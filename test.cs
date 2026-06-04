########## 1 #########

using System.IO.Pipelines;
using System.Runtime.Versioning;

[Route("api/cinema")]
[ApiController]
public class ShowtimesController : ControllerBase
{
    private readonly IShowtimesAction _shows;

    public ShowtimesController()
    {
        var bl = new BusinessLogic.BusinessLogic();
        _shows = bl.GetShowtimesActions();
    }

    [HttpGet("shows/{movieId}")]
    public IActionResult GetForMovie(int movieId)
    {
        var list = _shows.GetShowtimesForMovie(int movieId);
        return Ok(list);
    }
}

public interface IShowtimesAction
{
    List<DateTime> GetShowtimesForMovie(int movieId);
}

public class ShowtimesFlow : ShowtimesAction, IShowtimesAction
{
    public List<DateTime> GetShowtimesForMovie(int movieId)
    {
        return ExecuteGetShowtimesForMovie(movieId);
    }
}

public class ShowtimesAction
{
    protected List<DateTime> ExecuteGetShowtimesForMovie(movieId)
    {
        // логика
        return list;
    }
}


############### 2 ####################
[Route("api/parking")]
[ApiController]
public class SlotController : ControllerBase
{
    private readonly ISlotAction _slot;

    public SlotController()
    {
        var bl = new BusinessLogic.BusinessLogic();
        _slot = bl.GetSlotActions();
    }

    [HttpPost("release/{slotId}")]
    public IActionResult Release(int slotId)
    {
        var released = _slot.ReleaseParkingSlot(slotId);
        if (!released)
        {
            return BadRequest("Slot already free or not found");
        }
        return Ok();
    }
}

public interface ISlotAction
{
    bool ReleaseParkingSlot(int slotId);
}

public class SlotFlow : SlotAction, ISlotAction
{
    public bool ReleaseParkingSlot(int slotId)
    {
        return ExecuteReleaseParkingSlot(slotId);
    }
}

public class SlotAction
{
    protected bool ExecuteReleaseParkingSlot(int slotId)
    {
        // some logic
        return Status;
    }
}

###################### 3 ##################
[Route("api/clinic")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientAction _patient;

    public PatientController()
    {
        var bl = new BusinessLogic.BusinessLogic();
        _patient = bl.GetPatientActions();
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] PatientDto data)
    {
        var result = _patient.RegisterPatient(data);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(new { patientId = result.Message });
    }
}

public class PatientDto
{
    public string patientId {get; set;}
}

public class ResponseMsg
{
    public bool IsSuccess {get;set;}
    public string Message {get;set;}
}

public interface IPatientAction
{
    ResponseMsg RegisterPatient(PatientDto data);
}

public class PatientFlow : PatientAction, IPatientAction
{
    public ResponseMsg RegisterPatient(PatientDto data)
    {
        return ExecuteRegisterPatient(data);
    }
}

public class PatientAction
{
    protected ResponseMsg ExecuteRegisterPatient(PatientDto data)
    {
        // some logic
        return new ResponseMsg { IsSuccess = true, Message="..." };
    }
}

################ 4 ##################
[Route("api/gym")]
[ApiController]
public class AccessController : ControllerBase
{
    private readonly IAccessAction _access;

    public AccessController()
    {
        var bl = new BusinessLogic.BusinessLogic();
        _access = bl.GetAccessActions();
    }

    [HttpPost("access-code")]
    public IActionResult Generate([FromBody] MemberCheckDto data)
    {
        var code = _access.GenerateAccessCode(data);
        if (string.IsNullOrEmpty(code))
        {
            return Unauthorized();
        }
        return Ok(new { code });
    }
}

public class MemberCheckDto
{
    // какие-то поля
}

public interface IAccessAction
{
    string GenerateAccessCode(MemberCheckDto data);
}

public class AccessFlow : AccessAction, IAccessAction
{
    public string GenerateAccessCode(MemberCheckDto data)
    {
        return ExecuteGenerateAccessCode(data);
    }
}

public class AccessAction
{
    protected string ExecuteGenerateAccessCode(MemberCheckDto data)
    {
        // some logic
        return accessCode;
    }
}

################# 5 ####################### 
[Route("api/booking")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingAction _booking;

    public BookingController()
    {
        var bl = new BusinessLogic.BusinessLogic();
        _booking = bl.GetBookingActions();
    }

    [HttpDelete("{id}")]
    public IActionResult Cancel(int id, [FromQuery] int userId)
    {
        var owns = _booking.CheckOwnership(id, userId);
        if (!owns.IsSuccess)
        {
            return Unauthorized(owns.Message);
        }

        var result = _booking.CancelBooking(id);
        return Ok(result.Message);
    }
}

public class ResponseMsg
{
    public bool IsSuccess {get;set;}
    public string Message {get;set;}
}

public interface IBookingAction
{
    ResponseMsg CheckOwnership(int id, int userId);
    ResponseMsg CancelBooking(int id);
}

public class BookingFlow : BookingAction, IBookingAction
{
    public ResponseMsg CheckOwnership(int id, int userId)
    {
        return ExecuteCheckOwnership(id, userId);
    }

    public ResponseMsg CancelBooking(int id)
    {
        return ExecuteCancelBooking(id);
    }
}

public class BookingAction
{
    protected ResponseMsg ExecuteCheckOwnership(int id, int userId)
    {
        //some logic
        return new ResponseMsg { IsSuccess = true, Message = "..." };
    }

    protected ResponseMsg ExecuteCancelBooking(int id)
    {
        return new ResponseMsg { IsSuccess = true, Message = "..." };
    }
}

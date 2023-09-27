using System.Text.Json;
using System.Text.Json.Serialization;

namespace Paybyrd.Clients.Webhook.ValueObjects;

public readonly record struct Event
{
    private const string CHARGEBACK_CLOSED = "chargeback.closed";
    private const string CHARGEBACK_CREATED = "chargeback.created";
    private const string CHARGEBACK_DISPUTING = "chargeback.disputing";
    private const string CHARGEBACK_LOST = "chargeback.lost";
    private const string CHARGEBACK_PENDINGACTION = "chargeback.pendingaction";
    private const string CHARGEBACK_WON = "chargeback.won";
    private const string ORDER_CANCELED = "order.canceled";
    private const string ORDER_CAPTURE_CANCELED = "order.capture.canceled";
    private const string ORDER_CAPTURE_ERROR = "order.capture.error";
    private const string ORDER_CAPTURE_FAILED = "order.capture.failed";
    private const string ORDER_CAPTURE_PENDING = "order.capture.pending";
    private const string ORDER_CAPTURE_SUCCESS = "order.capture.success";
    private const string ORDER_CREATED = "order.created";
    private const string ORDER_EXPIRED = "order.expired";
    private const string ORDER_PAID = "order.paid";
    private const string ORDER_PARTIALPAID = "order.partialpaid";
    private const string ORDER_PARTIALREFUNDED = "order.partialrefunded";
    private const string ORDER_PAYMENT_CANCELED = "order.payment.canceled";
    private const string ORDER_PAYMENT_ERROR = "order.payment.error";
    private const string ORDER_PAYMENT_FAILED = "order.payment.failed";
    private const string ORDER_PAYMENT_PENDING = "order.payment.pending";
    private const string ORDER_PAYMENT_SUCCESS = "order.payment.success";
    private const string ORDER_PENDING = "order.pending";
    private const string ORDER_PREAUTH_CANCELED = "order.preauth.canceled";
    private const string ORDER_PREAUTH_ERROR = "order.preauth.error";
    private const string ORDER_PREAUTH_FAILED = "order.preauth.failed";
    private const string ORDER_PREAUTH_PENDING = "order.preauth.pending";
    private const string ORDER_PREAUTH_SUCCESS = "order.preauth.success";
    private const string ORDER_REFUND_CANCELED = "order.refund.canceled";
    private const string ORDER_REFUND_ERROR = "order.refund.error";
    private const string ORDER_REFUND_FAILED = "order.refund.failed";
    private const string ORDER_REFUND_PENDING = "order.refund.pending";
    private const string ORDER_REFUND_SUCCESS = "order.refund.success";
    private const string ORDER_REFUNDED = "order.refunded";
    private const string ORDER_TEMPORARYFAILED = "order.temporaryfailed";
    private const string TRANSACTION_CAPTURE_CANCELED = "transaction.capture.canceled";
    private const string TRANSACTION_CAPTURE_ERROR = "transaction.capture.error";
    private const string TRANSACTION_CAPTURE_FAILED = "transaction.capture.failed";
    private const string TRANSACTION_CAPTURE_PENDING = "transaction.capture.pending";
    private const string TRANSACTION_CAPTURE_SUCCESS = "transaction.capture.success";
    private const string TRANSACTION_PAYMENT_CANCELED = "transaction.payment.canceled";
    private const string TRANSACTION_PAYMENT_ERROR = "transaction.payment.error";
    private const string TRANSACTION_PAYMENT_FAILED = "transaction.payment.failed";
    private const string TRANSACTION_PAYMENT_PENDING = "transaction.payment.pending";
    private const string TRANSACTION_PAYMENT_SUCCESS = "transaction.payment.success";
    private const string TRANSACTION_PREAUTH_CANCELED = "transaction.preauth.canceled";
    private const string TRANSACTION_PREAUTH_ERROR = "transaction.preauth.error";
    private const string TRANSACTION_PREAUTH_FAILED = "transaction.preauth.failed";
    private const string TRANSACTION_PREAUTH_PENDING = "transaction.preauth.pending";
    private const string TRANSACTION_PREAUTH_SUCCESS = "transaction.preauth.success";
    private const string TRANSACTION_REFUND_CANCELED = "transaction.refund.canceled";
    private const string TRANSACTION_REFUND_ERROR = "transaction.refund.error";
    private const string TRANSACTION_REFUND_FAILED = "transaction.refund.failed";
    private const string TRANSACTION_REFUND_PENDING = "transaction.refund.pending";
    private const string TRANSACTION_REFUND_SUCCESS = "transaction.refund.success";

    public static Event None = new(string.Empty);

    private Event(string value)
    {
        Value = value;
    }

    public static Event ChargebackClosed => new(CHARGEBACK_CLOSED);
    public static Event ChargebackCreated => new(CHARGEBACK_CREATED);
    public static Event ChargebackDisputing => new(CHARGEBACK_DISPUTING);
    public static Event ChargebackLost => new(CHARGEBACK_LOST);
    public static Event ChargebackPendingAction => new(CHARGEBACK_PENDINGACTION);
    public static Event ChargebackWon => new(CHARGEBACK_WON);
    public static Event OrderCanceled => new(ORDER_CANCELED);
    public static Event OrderCaptureCanceled => new(ORDER_CAPTURE_CANCELED);
    public static Event OrderCaptureError => new(ORDER_CAPTURE_ERROR);
    public static Event OrderCaptureFailed => new(ORDER_CAPTURE_FAILED);
    public static Event OrderCapturePending => new(ORDER_CAPTURE_PENDING);
    public static Event OrderCaptureSuccess => new(ORDER_CAPTURE_SUCCESS);
    public static Event OrderCreated => new(ORDER_CREATED);
    public static Event OrderExpired => new(ORDER_EXPIRED);
    public static Event OrderPaid => new(ORDER_PAID);
    public static Event OrderPartialPaid => new(ORDER_PARTIALPAID);
    public static Event OrderPartialRefunded => new(ORDER_PARTIALREFUNDED);
    public static Event OrderPaymentCanceled => new(ORDER_PAYMENT_CANCELED);
    public static Event OrderPaymentError => new(ORDER_PAYMENT_ERROR);
    public static Event OrderPaymentFailed => new(ORDER_PAYMENT_FAILED);
    public static Event OrderPaymentPending => new(ORDER_PAYMENT_PENDING);
    public static Event OrderPaymentSuccess => new(ORDER_PAYMENT_SUCCESS);
    public static Event OrderPending => new(ORDER_PENDING);
    public static Event OrderPreAuthCanceled => new(ORDER_PREAUTH_CANCELED);
    public static Event OrderPreAuthError => new(ORDER_PREAUTH_ERROR);
    public static Event OrderPreAuthFailed => new(ORDER_PREAUTH_FAILED);
    public static Event OrderPreAuthPending => new(ORDER_PREAUTH_PENDING);
    public static Event OrderPreAuthSuccess => new(ORDER_PREAUTH_SUCCESS);
    public static Event OrderRefundCanceled => new(ORDER_REFUND_CANCELED);
    public static Event OrderRefunded => new(ORDER_REFUNDED);
    public static Event OrderRefundError => new(ORDER_REFUND_ERROR);
    public static Event OrderRefundFailed => new(ORDER_REFUND_FAILED);
    public static Event OrderRefundPending => new(ORDER_REFUND_PENDING);
    public static Event OrderRefundSuccess => new(ORDER_REFUND_SUCCESS);
    public static Event OrderTemporaryFailed => new(ORDER_TEMPORARYFAILED);
    public static Event TransactionCaptureCanceled => new(TRANSACTION_CAPTURE_CANCELED);
    public static Event TransactionCaptureError => new(TRANSACTION_CAPTURE_ERROR);
    public static Event TransactionCaptureFailed => new(TRANSACTION_CAPTURE_FAILED);
    public static Event TransactionCapturePending => new(TRANSACTION_CAPTURE_PENDING);
    public static Event TransactionCaptureSuccess => new(TRANSACTION_CAPTURE_SUCCESS);
    public static Event TransactionPaymentCanceled => new(TRANSACTION_PAYMENT_CANCELED);
    public static Event TransactionPaymentError => new(TRANSACTION_PAYMENT_ERROR);
    public static Event TransactionPaymentFailed => new(TRANSACTION_PAYMENT_FAILED);
    public static Event TransactionPaymentPending => new(TRANSACTION_PAYMENT_PENDING);
    public static Event TransactionPaymentSuccess => new(TRANSACTION_PAYMENT_SUCCESS);
    public static Event TransactionPreAuthCanceled => new(TRANSACTION_PREAUTH_CANCELED);
    public static Event TransactionPreAuthError => new(TRANSACTION_PREAUTH_ERROR);
    public static Event TransactionPreAuthFailed => new(TRANSACTION_PREAUTH_FAILED);
    public static Event TransactionPreAuthPending => new(TRANSACTION_PREAUTH_PENDING);
    public static Event TransactionPreAuthSuccess => new(TRANSACTION_PREAUTH_SUCCESS);
    public static Event TransactionRefundCanceled => new(TRANSACTION_REFUND_CANCELED);
    public static Event TransactionRefundError => new(TRANSACTION_REFUND_ERROR);
    public static Event TransactionRefundFailed => new(TRANSACTION_REFUND_FAILED);
    public static Event TransactionRefundPending => new(TRANSACTION_REFUND_PENDING);
    public static Event TransactionRefundSuccess => new(TRANSACTION_REFUND_SUCCESS);

    public string Value { get; }

    public static Event Create(string? @event)
    {
        if (string.IsNullOrWhiteSpace(@event))
        {
            return None;
        }

        return new Event(@event);
    }

    internal class ArrayConverter : JsonConverter<Event[]>
    {
        public override Event[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var events = JsonSerializer.Deserialize<string[]>(ref reader, options) ?? Array.Empty<string>();
            return events.Select(Create).ToArray();
        }

        public override void Write(Utf8JsonWriter writer, Event[] value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Select(x => x.Value).ToArray(), options);
        }
    }

    internal class Converter : JsonConverter<Event>
    {
        public override Event Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var @event = JsonSerializer.Deserialize<string>(ref reader, options);
            return Create(@event);
        }

        public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}

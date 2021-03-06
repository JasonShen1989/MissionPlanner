
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;

using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int64_t = System.Int64;

using float32 = System.Single;

using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace UAVCAN
{
public partial class uavcan {



/*

static uavcan_message_descriptor_s ardupilot_gnss_Heading_descriptor = {
    ARDUPILOT_GNSS_HEADING_DT_SIG,
    ARDUPILOT_GNSS_HEADING_DT_ID,
    CanardTransferTypeBroadcast,
    sizeof(ardupilot_gnss_Heading),
    ARDUPILOT_GNSS_HEADING_MAX_PACK_SIZE,
    encode_func,
    decode_func,
    null
};
*/

static void encode_ardupilot_gnss_Heading(ardupilot_gnss_Heading msg, uavcan_serializer_chunk_cb_ptr_t chunk_cb, object ctx) {
    uint8_t[] buffer = new uint8_t[8];
    _encode_ardupilot_gnss_Heading(buffer, msg, chunk_cb, ctx, true);
}

static uint32_t decode_ardupilot_gnss_Heading(CanardRxTransfer transfer, ardupilot_gnss_Heading msg) {
    uint32_t bit_ofs = 0;
    _decode_ardupilot_gnss_Heading(transfer, ref bit_ofs, msg, true);
    return (bit_ofs+7)/8;
}

static void _encode_ardupilot_gnss_Heading(uint8_t[] buffer, ardupilot_gnss_Heading msg, uavcan_serializer_chunk_cb_ptr_t chunk_cb, object ctx, bool tao) {

    memset(buffer,0,8);
    canardEncodeScalar(buffer, 0, 1, msg.heading_valid);
    chunk_cb(buffer, 1, ctx);
    memset(buffer,0,8);
    canardEncodeScalar(buffer, 0, 1, msg.heading_accuracy_valid);
    chunk_cb(buffer, 1, ctx);
    memset(buffer,0,8);
    canardEncodeScalar(buffer, 0, 32, msg.heading);
    chunk_cb(buffer, 32, ctx);
    memset(buffer,0,8);
    canardEncodeScalar(buffer, 0, 32, msg.heading_accuracy);
    chunk_cb(buffer, 32, ctx);
}

static void _decode_ardupilot_gnss_Heading(CanardRxTransfer transfer,ref uint32_t bit_ofs, ardupilot_gnss_Heading msg, bool tao) {

    canardDecodeScalar(transfer, bit_ofs, 1, false, ref msg.heading_valid);
    bit_ofs += 1;

    canardDecodeScalar(transfer, bit_ofs, 1, false, ref msg.heading_accuracy_valid);
    bit_ofs += 1;

    canardDecodeScalar(transfer, bit_ofs, 32, true, ref msg.heading);
    bit_ofs += 32;

    canardDecodeScalar(transfer, bit_ofs, 32, true, ref msg.heading_accuracy);
    bit_ofs += 32;

}

}
}
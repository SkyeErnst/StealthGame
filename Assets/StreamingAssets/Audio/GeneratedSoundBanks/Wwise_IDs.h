/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMBIENCERESUME = 138832960U;
        static const AkUniqueID FOFSTART = 1295469290U;
        static const AkUniqueID GAMESTART = 4058101365U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace ALERTLEVEL
        {
            static const AkUniqueID GROUP = 1321250609U;

            namespace STATE
            {
                static const AkUniqueID FOF = 1083137562U;
                static const AkUniqueID NOALERT = 713054966U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace ALERTLEVEL

        namespace MUSIC_LEVEL1
        {
            static const AkUniqueID GROUP = 2209143526U;

            namespace STATE
            {
                static const AkUniqueID BASE = 1291433366U;
                static const AkUniqueID FIGHTORFLIGHT = 1259773148U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSIC_LEVEL1

    } // namespace STATES

    namespace SWITCHES
    {
        namespace BASE
        {
            static const AkUniqueID GROUP = 1291433366U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace BASE

        namespace FIGHTORFLIGHT
        {
            static const AkUniqueID GROUP = 1259773148U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace FIGHTORFLIGHT

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
